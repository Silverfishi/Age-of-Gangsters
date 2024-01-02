using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour
{
    

    //Цвет фракций
    public static Color lsv_color = new Color(0.6F, 0.5F, 0.0F);
    public static Color fam_color = new Color(0.1f, 0.5f, 0.1f);
    public static Color lva_color = new Color(0.2F, 0.5F, 0.9F);
    public static Color sfr_color = new Color(0.3F, 0.3F, 0.5F);
    public static Color bal_color = new Color(0.4F, 0.2F, 0.5F);
    public static Color square_shadow = new Color(0.1F, 0.1F, 0.1F);
    public static Color color_square_with_shadow;
    public static Color color_of_the_selected_square;
    //перехват старого цвета клетки
    public static Color old_square_color;

    //Кнопки
    /*
    public GameObject square_up;
    public GameObject square_right;
    public GameObject square_down;
    public GameObject square_left;
    public GameObject old_square_up;
    public GameObject old_square_right;
    public GameObject old_square_down;
    public GameObject old_square_left;

    public GameObject add_button;
    public GameObject remove_button;
    public GameObject enter_button;
    public GameObject move_units_button;
    */

    //Активация кнопок при нажатии по клетке своей фракции
    public static bool activate_buttons = false;
    public static Color inactive_button = new Color(0.5f, 0.5f, 0.5f);                  
    public static Color add_button_activate = new Color(0.4f, 0.9f, 0.4f);              
    public static Color remove_button_activate = new Color(0.9f, 0.4f, 0.4f);           
    public static Color enter_button_activate = new Color(0.4f, 0.4f, 0.9f);            
    public static Color move_units_button_activate = new Color(0.5f, 0.5f, 0.9f);

    //перехват старого цвета кнопок
    public static Color square_up_old_color;
    public static Color square_right_old_color;
    public static Color square_down_old_color;
    public static Color square_left_old_color;
    public static bool capturing_the_top_square = false;
    public static bool capturing_the_right_square = false;
    public static bool capturing_the_bottom_square = false;
    public static bool capturing_the_left_square = false;
}
