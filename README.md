# GraniteWarehouse
What Is Task<>? 
Where is the difference bewteen controller and razor pages? I like the controller. It keeps things seperate.
I had a thought about this during chapter 11
One thing I notice was the controller and methods in a class. I found it interesting that the controller is mostly just passing data back and forth bewteen the controller. And if a model needs to make a change the controller pass in info to the class and the method of that class makes the chnage. I always was thinking that the controller did all the moving and changing. EFRepository has a save function and delete function. 
[HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId); //function in the EFrepostitory
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
        It's a function in a controller calling another function outsides of its domain. It's just passing information. This makes a lot more sense to me after this chapter. Contrllers move things. 
        My question: When do you make the line of what the controller to do? Am I correct in what I'm thinking here?
