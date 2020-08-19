using System;
using Xunit;

namespace Sadguru_AmritTulya_UI_Auto
{
    public class InventoryPage
    {
        public InventoryPage()
        {
            /*
             * Open Browser Instance
             * Deal with repoeting and fixture stuff
             */
        }
        [Fact]
        public void Should_View_ProductList()
        {
            /*
             * Open browser
             * Navigate to that Page
             * Check the list of product
             */
        }

        [Fact]
        public void Should_Add_Product()
        {
            /*
             * Navigate to that Page
             * Check if Add component is presnt on page
             * Click on that component
             * Enter name,price and description 
             * Submit
             * Validate in product lists if new product is added
             */
        }

        [Fact]
        public void Should_Not_Add_Prduct_With_Missing_Info()
        {
            /*
             * Open browser
             * Navigate to that Page
             * Check if Add component is presnt on page
             * Click on that component
             * Enter name and description 
             * Submit
             * Validate if warning/error message is present on screen
             */
        }

        [Fact]
        public void Should_Remove_Product()
        {
            /*
             * Open browser
             * Navigate to that Page
             * Check if remove component is presnt on page
             * Click on that component
             * Click on confirmation prompt
             * Submit
             * Validate that product lists does not contain removed product 
             */
        }

        [Fact]
        public void Should_View_Detailed_Product()
        {
            /*
             * Open browser
             * Navigate to that Page
             * Check the list of product
             * Click on one of the product
             * Wait for new page to launch
             * check all the content is same as of clicked product
             * close new tab
             */
        }
    }
}
