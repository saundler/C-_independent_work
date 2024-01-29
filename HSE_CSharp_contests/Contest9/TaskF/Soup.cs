using System;
using System.Linq;

internal class Soup
{
    Ingredient[] ingredients;
    public Soup(Ingredient[] ingredients) => this.ingredients = ingredients;

    public bool WillEat 
    { 
        get
        {
            foreach (Ingredient ingredient in ingredients)
                if ((ingredient is Meat && !((Meat)ingredient).IsTasty) ||
                   (ingredient is Vegetable && ((Vegetable)ingredient).IsAllergicTo))
                    return false;
            return true;
        }
    }
}