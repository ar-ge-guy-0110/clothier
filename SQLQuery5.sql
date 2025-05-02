SELECT user_outfit_combination.id AS 'Combination ID', user_outfit_combination.user_id AS 'User ID', 
user_outfit_combination.combination_name AS 'Combination Name', cloth.cloth_name AS dress_slot, 
cloth2.cloth_name AS topwear_slot, cloth3.cloth_name AS bottomwear_slot, cloth4.cloth_name AS shoe_slot, 
cloth5.cloth_name AS bag_slot, user_outfit_combination.sharing AS 'Sharing Status' FROM user_outfit_combination 
LEFT JOIN cloth ON user_outfit_combination.dress_slot = cloth.id 
LEFT JOIN cloth AS cloth2 ON user_outfit_combination.topwear_slot = cloth2.id 
LEFT JOIN cloth AS cloth3 ON user_outfit_combination.bottomwear_slot = cloth3.id 
LEFT JOIN cloth AS cloth4 ON user_outfit_combination.shoe_slot = cloth4.id 
LEFT JOIN cloth AS cloth5 ON user_outfit_combination.bag_slot = cloth5.id