namespace LordBreakerX.Inventory
{
    public class LootItem
    {
        public Item Item { get; private set; }
        public int Count { get; private set; }

        public LootItem(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
