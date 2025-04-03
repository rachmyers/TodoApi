using TodoApi.Controllers;
using TodoApi.Models;

namespace TodoApiUnitTests
{
    [TestClass]
    public sealed class TodoItemsControllerTests
    {

        [TestMethod]
        public async void GetTodoItems_ValidID_ReturnItem()
        {
            //Arrange
            var item = new TodoItem
            {
                Id = 1,
                Name = "Complete unit testing setup",
                IsComplete = true,
                Secret = ""
            };

            //var context = new TodoContext();


            //TodoItemsController controller = new TodoItemsController();

            //Assert.IsNotNull(controller.GetTodoItem(1));
            
            
        }

        public void GetTodoItems_InvalidID_ReturnNotFound()
        {

        }

        public void GetTodoItems_NullID_ReturnNotFound()
        {

        }
    }
}
