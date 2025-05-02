SELECT user_body_mass_index.bmi, 
body_type.body_type_name, body_type.id, 
cloth_clothingstyle_category.category_name, cloth_clothingstyle_category.id, 
cloth_season_category.category_name, cloth_season_category.id,
cloth_place_category.category_name, cloth_place_category.id FROM user_body_mass_index 
JOIN user_account ON user_body_mass_index.user_id = user_account.id 
JOIN user_which_body_type ON user_account.id = user_which_body_type.user_id JOIN body_type ON user_which_body_type.body_type_id = body_type.id 
JOIN user_which_clothingstyle ON user_account.id = user_which_clothingstyle.user_id JOIN cloth_clothingstyle_category ON user_which_clothingstyle.clothingstyle_id = cloth_clothingstyle_category.id 
JOIN user_which_season ON user_account.id = user_which_season.user_id JOIN cloth_season_category ON user_which_season.clothing_season_id = cloth_season_category.id 
JOIN user_which_place ON user_account.id = user_which_place.user_id JOIN cloth_place_category ON user_which_place.clothing_place_id = cloth_place_category.id 
WHERE user_account.id = 1
