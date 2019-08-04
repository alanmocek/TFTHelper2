using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTHelper2.Application.Items
{
    public class ViewModelItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Bonus { get; set; }
        public int Depth { get; set; }
        public List<string> BuildsFrom { get; set; } = new List<string>();
        public List<ViewModelRecipe> Recipes { get; set; } = new List<ViewModelRecipe>();
        public bool IsHiden { get; set; }
        public string IconPath => $"/Resources/ItemsIcons/{Key}.png";
        public int Order { get; set; }

        public void CreateRecipes(List<ViewModelItem> items)
        {
            if(Depth!=1)
            {
                return;
            }

            foreach(ViewModelItem i in items)
            {
                if(i.BuildsFrom.Contains(Key))
                {
                    ViewModelRecipe recipe = new ViewModelRecipe();

                    var additionalItemKey = i.BuildsFrom.SingleOrDefault(x => x != Key);

                    if(additionalItemKey == null)
                    {
                        additionalItemKey = Key;
                    }

                    var additionalItem = items.SingleOrDefault(item => item.Key == additionalItemKey);

                    var resultItem = items.SingleOrDefault(item => item.Key == i.Key);

                    recipe.AdditionalItem = additionalItem;
                    recipe.ResultItem = resultItem;

                    Recipes.Add(recipe);
                }
            }

            Recipes = Recipes.OrderBy(r => r.AdditionalItem.Order).ToList();
        }
    }
}
