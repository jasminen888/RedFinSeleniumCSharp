# RedFinSeleniumCSharp
#This project is proprietary. All rights reserved. You may not use, modify, or distribute the code without explicit permission from the author **Jasmine Ng**

# Description:
Search for properties in Portland, OR on Redfin.com with three filters applied, and verify the results returned match the search criteria.

### Steps:

1. **Open any Browser** and go to [Redfin.com](https://www.redfin.com/).
   
2. **Enter Portland, OR** in the city search box.

3. **Select the following filters**:
   - **Filter #1: Price Range**
     - Click on the **Price** dropdown to open the Price List box.
     - Enter a minimum price in the **“Enter min”** box and a maximum price in the **‘Enter max’** box.
     - Click the **Done** button.
   
   - **Filter #2: Beds/Baths**
     - Click on the **Beds/baths** dropdown to open the Beds/baths List.
     - Under **Beds**, select **3** and leave **Baths** at **Any** (default).
     - Click the **Done** button.

   - **Filter #3: Home Type**
     - Click on the **Home Type** dropdown to open the Home Type List.
     - Select **House**.
     - Click the **Done** button.

4. **Click the Search button** to view the results.

5. **Verify the displayed results**:
   - Ensure that the results returned match the applied 3 filters.
   - The search results should display properties in Portland within the set price range and with **3 bedrooms**.

### Note:
Redfin does not show “House” explicitly in the listings, but the filter ensures only houses appear in the results.

###[GitHub](https://github.com/jasminen888/RedFinSeleniumCSharp)###

