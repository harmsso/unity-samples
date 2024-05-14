namespace Localization.TextLocalization
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILocalizable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizedLine"></param>
        public void Localize(string localizedLine);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetLineToLocalize();
    }
}