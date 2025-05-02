SELECT user_outfit_combination.dress_slot, cloth_image.image, 
user_outfit_combination.topwear_slot, cloth_image2.image, 
user_outfit_combination.bottomwear_slot, cloth_image3.image, 
user_outfit_combination.shoe_slot, cloth_image4.image, 
user_outfit_combination.bag_slot, cloth_image5.image FROM user_outfit_combination 
LEFT JOIN cloth_image ON user_outfit_combination.dress_slot = cloth_image.cloth_id 
LEFT JOIN cloth_image AS cloth_image2 ON user_outfit_combination.topwear_slot = cloth_image2.cloth_id 
LEFT JOIN cloth_image AS cloth_image3 ON user_outfit_combination.bottomwear_slot = cloth_image3.cloth_id 
LEFT JOIN cloth_image AS cloth_image4 ON user_outfit_combination.shoe_slot = cloth_image4.cloth_id 
LEFT JOIN cloth_image AS cloth_image5 ON user_outfit_combination.bag_slot = cloth_image5.cloth_id WHERE user_outfit_combination.id = 5