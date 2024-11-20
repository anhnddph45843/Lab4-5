using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }



    public class ItemManager
    {
        public List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            if (string.IsNullOrEmpty(item.Name) || !IsValidName(item.Name))
            {
                throw new ArgumentException("Error 404");
            }

            if (item.Name.Length > 10)
            {
                throw new ArgumentException("Error 405 ");
            }

            items.Add(item);
        }

        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public void UpdateItem(int id, string newName)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                if (string.IsNullOrEmpty(newName) || !IsValidName(newName))
                {
                    throw new ArgumentException("Error 404");
                }

                if (newName.Length > 10)
                {
                    throw new ArgumentException("Error 405 ");
                }
                item.Name = newName;
            }
        }

        public void DeleteItem(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }
    }

    public class Test
    {
        private ItemManager isv;

        [SetUp]
        public void Setup()
        {
            isv = new ItemManager();
        }

        [Test]
        public void AddItem_ValidItem_ShouldAddItem()
        {
            var item = new Item(1, "ValidItem");

            isv.AddItem(item);

            Assert.AreEqual(1, isv.items.Count);
            Assert.AreEqual(item, isv.items[0]);
        }

        [Test]
        public void AddItem_ItemNameTooLong_ShouldThrowException()
        {
            var item = new Item(1, new string('a', 21));

            Assert.Throws<ArgumentException>(() => isv.AddItem(item));
        }

        [Test]
        public void AddItem_ItemNameNotString_ShouldThrowException()
        {
            var item = new Item(1, "123");

            Assert.Throws<ArgumentException>(() => isv.AddItem(item));
        }

        [Test]
        public void UpdateItem_ValidItem_ShouldUpdateItem()
        {
            var item = new Item(1, "Name");
            isv.AddItem(item);
            var newName = "Ten1";

            isv.UpdateItem(1, newName);

            Assert.AreEqual(newName, isv.items[0].Name);
        }

        [Test]
        public void UpdateItem_ItemNotFound_ShouldDoNothing()
        {
            var newName = "Update Name";

            isv.UpdateItem(1, newName);

            Assert.AreEqual(0, isv.items.Count);
        }

        [Test]
        public void UpdateItem_ItemNameTooLong_ShouldThrowException()
        {
            var item = new Item(1, "Ten");
            isv.AddItem(item);
            var newName = "TenQuaDai";

            Assert.Throws<ArgumentException>(() => isv.UpdateItem(1, newName));
        }

        [Test]
        public void UpdateItem_ItemNameNotString_ShouldThrowException()
        {
            var item = new Item(1, "OriName");
            isv.AddItem(item);
            var newName = 123;

            Assert.Throws<ArgumentException>(() => isv.UpdateItem(1, newName.ToString()));
        }

        [Test]
        public void DeleteItem_ExistingItem_ShouldDeleteItem()
        {
            var item = new Item(1, "ItemtoDele");
            isv.AddItem(item);

            isv.DeleteItem(1);

            Assert.AreEqual(0, isv.items.Count);
        }

        [Test]
        public void DeleteItem_ItemNotFound_ShouldDoNothing()
        {
            isv.DeleteItem(1);

            Assert.AreEqual(0, isv.items.Count);
        }
    }
}