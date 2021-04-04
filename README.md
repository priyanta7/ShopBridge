## ShopBridge .NET WEB API Project

- Assuming the ShopBridge project code is cloned and the Solution is being run successfully

- The below steps need to be performed : 

-install the following nuget packages- 1.Microsoft.Entityframeworkcore.sqlserver
                                       2.Microsoft.Entityframeworkcore.tools
                                       3.Moq
                                       4.FluentAssertions

-Now, Go to appsettings.json  and change the server name "Desktop-HRF1STA" to your local server name that you can find in Microsoft sql server. Refer to to below screenshots for this step
![image](https://user-images.githubusercontent.com/81872507/113498327-915e3480-9529-11eb-9e20-417f528a8474.png)
change the highlighted portion to your local server
![image](https://user-images.githubusercontent.com/81872507/113498351-ca96a480-9529-11eb-8afc-a34d031922dc.png)
-you can get your local server name by referring to the above scrrenshot
-Now open the Nuget pacakge manager console and run the following command
- Add-Migration
- Update-Database
- Now Build the solution
- Run the projct from IIS
- Copy the path upto to the port number from the browser. refer to the below screenshot
- ![image](https://user-images.githubusercontent.com/81872507/113498473-cfa82380-952a-11eb-9f17-6dc7f288eb9a.png)
- To add products to the list now paste the URL  in the postman post method and write /api/products in the URL. Then go to body, change the text typer to JSON. provide the code body, as per the below screenshot. You can add your product name, description and pice as per your choice. You can add multiple products by follwing the same method each time. 
- ![image](https://user-images.githubusercontent.com/81872507/113498691-e2bbf300-952c-11eb-81bf-797533a98a36.png)

-Now to get the list of products along with the details you added, paste the same url in the postman 'get' method.Refer to the below screenshot.
-![image](https://user-images.githubusercontent.com/81872507/113498580-d97e5680-952b-11eb-871a-a5edbce57213.png)

-To delete a particular product copy thr Guid of the product from the result body in the get method, then paste it along with the same url in the delete method of postman. Refer to the below screenshot.
![image](https://user-images.githubusercontent.com/81872507/113498815-07649a80-952e-11eb-9c66-d64350ac1d42.png)
-After getting OK  response for the delete method, you can check the list of products again to verify whether it is deleted or not.

-To modify any particular products , copy the latest Guid of that product from the result body in the get method, then paste it along with the same url in the patch method of postman. Write the updates in the body. Refer to the below screenshot
-![image](https://user-images.githubusercontent.com/81872507/113498917-efd9e180-952e-11eb-9932-270e496c0909.png)
###Additional
-To check the code coverage : Go to Test-> Analyze code coverage for all test   in visual studio
