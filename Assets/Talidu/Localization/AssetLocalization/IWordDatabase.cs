namespace Localization.AssetLocalization
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWordDatabase
    {
        /// <summary>
        /// Return the requested <see cref="WordData"/> for the parameter <paramref name="word"></paramref>
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public WordData GetWord(string word);
    }
}