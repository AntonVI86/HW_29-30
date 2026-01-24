namespace InventoryHomework
{
    public class Item
    {
        private string _name;
        private int _count;

        public Item(string name, int count)
        {
            _name = name;
            _count = count;
        }

        public string Name => _name;
        public int Count => _count;

        public void Add(int value)
        {
            _count += value;
        }
    }
}
