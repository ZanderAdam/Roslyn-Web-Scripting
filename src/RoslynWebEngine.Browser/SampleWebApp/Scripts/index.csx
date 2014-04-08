public void AddNumbers()
{
    var value1 = GetElementById("number1").GetAttribute("value");
    var value2 = GetElementById("number2").GetAttribute("value");

    var result = int.Parse(value1) * int.Parse(value2);

    GetElementById("answer").InnerHtml = result.ToString();
}