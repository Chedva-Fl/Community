using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTest
{
    internal class TeacherControllerTest
    {
        private readonly FakeContext fakeContext = new FakeContext();
        [Fact]
        public void Get_ReturnList()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה

            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new EventsController(fakeContext);
            var result = controller.Get();

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<List<Events>>(result);
        }

        [Fact]
        public void Get_ReturnCount()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה

            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new EventsController(fakeContext);
            var result = controller.Get();

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetById_ReturnOk()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה
            var id = 89;
            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new EventsController(fakeContext);
            var result = controller.Get(id);

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            //AAA

            //ARRANGE - בחלק זה אנחנו נגדיר את המשתנים שצריך לשלוח לפונקציה
            var id = 8;
            //ACT - בחלק זה נפעיל את הפונקציה
            var controller = new EventsController(fakeContext);
            var result = controller.Get(id);

            //ASSERT - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל מהפונקציה
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Add_ReturnOk()
        {
            var e = new Events { Id = 3, Start = new DateTime(), End = new DateTime(), Title = "hkjgfd" };
            var controller = new EventsController(fakeContext);
            var result = controller.Post(e);
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
