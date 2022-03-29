namespace LCMTLCB1WebApplication.Services.DataModels
{
    public class Paging
    {
        private int _pageNumber;
        private int _items;
        private int _itemsOnPage;

        public int pageNumber
        {
            get
            {
                return _pageNumber < 1 ? 1 : _pageNumber;
            }
            set
            {
                _pageNumber = value;
            }
        }
        public int items
        {
            get
            {
                return _items < 0 ? 0 : _items;
            }
            set
            {
                _items = value;
            }
        }
        public int itemsOnPage
        {
            get
            {
                return _itemsOnPage;
            }
            set
            {
                _itemsOnPage = value;
            }
        }

        public int RowNumStart
        {
            get
            {
                return ((pageNumber - 1) * itemsOnPage);
            }
        }

        public int RowNumEnd
        {
            get
            {
                return (pageNumber * itemsOnPage) + 1;
            }
        }
         
    }
}
