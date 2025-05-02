SELECT cloth.id AS 'Cloth ID', 
cloth.cloth_name AS 'Cloth Name', 
cloth_category.category_name AS 'Main Category', 
cloth_subcategory.subcategory_name AS 'Sub Category', 
cloth_bmi_category.bmi_name AS 'BMI Category', 
body_type.body_type_name AS 'Body Type Category', 
cloth_clothingstyle_category.category_name AS 'Style', 
cloth_season_category.category_name AS 'Season', 
cloth_place_category.category_name AS 'Place' 
FROM cloth 
JOIN cloth_which_category ON cloth.id = cloth_which_category.cloth_id JOIN cloth_category ON cloth_which_category.cloth_category_id = cloth_category.id 
JOIN cloth_which_subcategory ON cloth.id = cloth_which_subcategory.cloth_id JOIN cloth_subcategory ON cloth_which_subcategory.cloth_subcategory_id = cloth_subcategory.id 
JOIN cloth_which_bmi_category ON cloth.id = cloth_which_bmi_category.cloth_id JOIN cloth_bmi_category ON cloth_which_bmi_category.cloth_bmi_category_id = cloth_bmi_category.id 
JOIN cloth_which_bodytype_category ON cloth.id = cloth_which_bodytype_category.cloth_id JOIN body_type ON cloth_which_bodytype_category.body_type_id = body_type.id 
JOIN cloth_which_clothingstyle_category ON cloth.id = cloth_which_clothingstyle_category.cloth_id JOIN cloth_clothingstyle_category ON cloth_which_clothingstyle_category.cloth_clothingstyle_category_id = cloth_clothingstyle_category.id 
JOIN cloth_which_season_category ON cloth.id = cloth_which_season_category.cloth_id JOIN cloth_season_category ON cloth_which_season_category.cloth_season_category_id = cloth_season_category.id 
JOIN cloth_which_place_category ON cloth.id = cloth_which_place_category.cloth_id JOIN cloth_place_category ON cloth_which_place_category.cloth_place_category_id = cloth_place_category.id WHERE cloth_category.id = 6