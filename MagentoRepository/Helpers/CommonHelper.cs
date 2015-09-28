namespace MagentoRepository.Helpers
{
    public static class CommonHelper
    {
        public static string FormatCurrency(string magentoPrice)
        {
            return magentoPrice.Length < 2 ? null : magentoPrice.Remove(magentoPrice.Length - 2, 2).Replace(".", ",");
        }
    }
}
