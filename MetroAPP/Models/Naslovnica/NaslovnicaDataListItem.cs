namespace MetroAPP.Models.Naslovnica
{
    public class NaslovnicaDataListItem
    {
        public NaslovnicaDataListItem(string dataListItemNaslov, string dataListItemText, string dataListImgSrc, string dataListActionLink,string itemHtmlPace)
        {
            DataListItemNaslov = dataListItemNaslov;
            DataListItemText = dataListItemText;
            DataListItemImgSrc = dataListImgSrc;
            DataListActionLink = dataListActionLink;
            ItemHtmlPlace = itemHtmlPace;
        }

        public int DataListId;
        public string DataListItemNaslov;
        public string DataListItemText;
        public string DataListItemImgSrc;
        public string DataListActionLink;
        public string ItemHtmlPlace;
    }
}