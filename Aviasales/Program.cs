using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text;

namespace AviasalesNew
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            IWebDriver driver = new ChromeDriver();

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                driver.Navigate().GoToUrl("https://www.aviasales.ru/");
                Console.WriteLine("Page title: " + driver.Title);

                ClosePopupIfExists(driver, wait);

                SelectCity(driver, wait, "input[data-test-id='origin-input']", "Москва", "li[data-test-id='suggested-city-MOW']");
                SelectCity(driver, wait, "input[data-test-id='destination-input']", "Санкт-Петербург", "li[data-test-id='suggested-city-LED']");

                SelectDepartureDate(driver, wait, DateTime.Today.AddDays(7));

                ClickSearch(driver, wait);

                SwitchToResultsTab(driver, wait);

                Console.WriteLine("Если появилась капча — пройди её вручную.");
                Console.WriteLine("После загрузки рейсов нажми Enter в консоли...");
                Console.ReadLine();

                SaveDirectFlightsToFile(driver, wait);

                Console.WriteLine("Нажми Enter, чтобы закрыть браузер...");
                Console.ReadLine();
            }
            finally
            {
                driver.Quit();
            }
        }

        static IWebElement WaitUntilClickable(WebDriverWait wait, By locator)
        {
            return wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed && element.Enabled ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        static IWebElement WaitUntilVisible(WebDriverWait wait, By locator)
        {
            return wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        static void ClosePopupIfExists(IWebDriver driver, WebDriverWait wait)
        {
            try
            {
                var stayOnSiteButton = WaitUntilClickable(
                    wait,
                    By.XPath("//button[.//div[contains(., 'Остаться') and contains(., 'сайте')]]"));

                stayOnSiteButton.Click();

                wait.Until(driver =>
                {
                    var elements = driver.FindElements(
                        By.XPath("//button[.//div[contains(., 'Остаться') and contains(., 'сайте')]]"));

                    return elements.Count == 0 || !elements[0].Displayed;
                });

                Console.WriteLine("Pop-up closed");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Pop-up doesn't appear");
            }
        }

        static void SelectCity(
            IWebDriver driver,
            WebDriverWait wait,
            string inputSelector,
            string cityName,
            string optionSelector)
        {
            var input = WaitUntilClickable(wait, By.CssSelector(inputSelector));
            input.Click();

            var activeInput = driver.SwitchTo().ActiveElement();

            activeInput.SendKeys(Keys.Control + "a");
            activeInput.SendKeys(Keys.Delete);
            activeInput.SendKeys(cityName);

            var cityOption = WaitUntilClickable(wait, By.CssSelector(optionSelector));

            Console.WriteLine("City option: " + cityOption.Text);
            cityOption.Click();

            Console.WriteLine("Город выбран: " + cityName);
        }

        static void SelectDepartureDate(IWebDriver driver, WebDriverWait wait, DateTime date)
        {
            var dateButton = WaitUntilClickable(
                wait,
                By.CssSelector("button[data-test-id='start-date-field']"));

            dateButton.Click();

            WaitUntilVisible(wait, By.XPath("//*[contains(., 'Цены за билет')]"));

            var formatted = date.ToString("yyyy-MM-dd");

            var departureDate = WaitUntilClickable(
                wait,
                By.CssSelector($"td[data-day='{formatted}']:not(.disabled) button"));

            departureDate.Click();

            var confirmButton = WaitUntilClickable(
                wait,
                By.CssSelector("button[data-test-id='calendar-action-button']"));

            Console.WriteLine("Confirm button: " + confirmButton.Text);
            confirmButton.Click();

            Console.WriteLine("Дата подтверждена: " + formatted);
        }

        static void ClickSearch(IWebDriver driver, WebDriverWait wait)
        {
            Console.WriteLine("Пробуем нажать Найти билеты");

            if (driver.Url.Contains("/search/"))
            {
                Console.WriteLine("Поиск уже выполнен");
                return;
            }

            var searchButton = wait.Until(d =>
            {
                var elements = d.FindElements(By.CssSelector("button[data-test-id='form-submit']"));

                if (elements.Count == 0)
                    return null;

                return elements[0];
            });

            searchButton.Click();

            Console.WriteLine("Нажали Найти билеты");
        }

        static void SwitchToResultsTab(IWebDriver driver, WebDriverWait wait)
        {
            wait.Until(d => d.WindowHandles.Count > 1);

            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Console.WriteLine("Переключились на вкладку результатов");
            Console.WriteLine("URL: " + driver.Url);
            Console.WriteLine("Title: " + driver.Title);
        }

        static void SaveDirectFlightsToFile(IWebDriver driver, WebDriverWait wait)
        {
            // ждём блок
            var section = WaitUntilVisible(
                wait,
                By.XPath("//*[contains(text(), 'Прямые рейсы')]"));

            // берём родительский контейнер (важно!)
            var container = section.FindElement(By.XPath("./ancestor::div[1]"));

            var text = container.Text;

            var lines = text.Split('\n');

            var filteredLines = lines
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Where(l => !l.Contains("₽"))
                .Where(l => !l.Contains("Зелёным отмечаем"))
                .Where(l => l != "Ок")
                .Distinct()
                .ToList();

            var resultText = string.Join("\n", filteredLines);

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "direct_flights.txt");

            File.WriteAllText(filePath, resultText, Encoding.UTF8);

            Console.WriteLine("Прямые рейсы сохранены:");
            Console.WriteLine(filePath);
        }
    }
}