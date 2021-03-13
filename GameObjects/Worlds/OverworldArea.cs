namespace NullRPG.GameObjects.Worlds
{
    public class OverworldArea : Area
    {
        public OverworldArea(string name) : base(name)
        {
        }

        public static OverworldArea Hometown()
        {
            var area = new OverworldArea("Hometown");

            area.AddLocation(OverworldLocation.Blacksmith());
            area.AddLocation(OverworldLocation.Home());

            return area;
        }

        public static OverworldArea Outskirts()
        {
            var area = new OverworldArea("Outskirts");

            area.AddLocation(OverworldLocation.Forest());
            area.AddLocation(OverworldLocation.Cave());

            return area;
        }
    }
}

/*
 *
        public static void CreateDefault<T>() where T : IEntityInventory
        {
            var inventory = Get<PlayerInventory>();
            // create the inventory
            while (inventory.Slots.Count < DEFAULT_INVENTORY_SIZE)
            {
                AddSlot<IEntityInventory>(new Slot(inventory.GetUniqueSlotId()));
            }
        }
 *
 *
 *
 */