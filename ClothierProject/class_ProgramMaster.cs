using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothierProject
{
    class class_ProgramMaster
    {
        public static string name = "Clothier";
        public static string version = "Development V0.001";

        //USER DATA

        public static string logged_user = "";
        public static int logged_user_id = -1;

        public static float user_body_mass_index = 0;
        public static string user_body_mass_string = "";
        public static bool isUserHasDefBmi = false;

        public static string user_bodytype = "";
        public static int user_bodytype_id = -1;
        public static bool isUserHasDefBodyType = false;

        public static string user_clothingstyle = "";
        public static int user_clothingstyle_id = -1;
        public static bool isUserHasDefClothingStyle = false;


        public static string user_place = "";
        public static int user_place_id = -1;
        public static bool isUserHasDefPlace = false;

        public static string user_season = "";
        public static int user_season_id = -1;
        public static bool isUserHasDefSeason = false;

        //PROGRAM DATA

        public static Form core_login_form;
        public static bool isOneTimeFormOpen = false;

        public static int cloth_id_for_combination = -1;
        public static string cloth_maincategory_for_combination = "";
        public static int cloth_maincategory_id_for_combination = -1;
    }
}
