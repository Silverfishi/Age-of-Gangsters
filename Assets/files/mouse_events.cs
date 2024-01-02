using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse_events: MonoBehaviour
{

//Кнопки
private GameObject square_up;
private GameObject square_right;
private GameObject square_down;
private GameObject square_left;
private GameObject old_square_up;
private GameObject old_square_right;
private GameObject old_square_down;
private GameObject old_square_left;

public GameObject add_button;
public GameObject remove_button;
public GameObject enter_button;
public GameObject move_units_button;

public Camera player_camera;
public GameObject lsv_unit_prefab;
public RaycastHit old_square;
public RaycastHit selected_object; 

void Start()
{                   
    player_camera = Camera.main;     
    config.activate_buttons = false;
}
void activating_and_deactivating_buttons () {
    config.color_of_the_selected_square = selected_object.collider.gameObject.GetComponent<Renderer>().material.color;
    if (config.color_of_the_selected_square == config.lsv_color || config.color_of_the_selected_square == config.lsv_color-config.color_square_with_shadow)
    {
        config.activate_buttons = true;
        add_button.GetComponent<Graphic>().color = config.add_button_activate;
        remove_button.GetComponent<Graphic>().color = config.remove_button_activate;
        enter_button.GetComponent<Graphic>().color = config.enter_button_activate;
        move_units_button.GetComponent<Graphic>().color = config.move_units_button_activate;
    }
    else if (config.activate_buttons && selected_object.collider.gameObject.name == "add_button") {
        Instantiate(lsv_unit_prefab, 
        new Vector3(0, 0, 0), 
        Quaternion.identity);
        print (selected_object.transform.position.x + " " + selected_object.transform.position.z);
    }

        //unit_spawner.lsv_units[0] += 10;

    else if (config.activate_buttons && selected_object.collider.gameObject.name == "remove_button")
        print ("пусто");
        //unit_spawner.lsv_units[0] -= 10;

    else if (config.activate_buttons && selected_object.collider.gameObject.name == "move_button")
        for (int x=0; x<=3; x++)
        {
            for (int y=0; y<=3; y++)
            {
                if (old_square.collider.gameObject.name == $"square X:{x} Y:{y}")
                {
                    int up = y+1;
                    int right = x+1;
                    int down = y-1;
                    int left = x-1;
                    if (up <= 3)
                    {
                        square_up = GameObject.Find($"square X:{x} Y:{up}");
                        config.square_up_old_color = square_up.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color;
                        square_up.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    }
                    if (right <= 3)
                    {
                        square_right = GameObject.Find($"square X:{right} Y:{y}");
                        config.square_right_old_color = square_right.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color;
                        square_right.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    }
                    if (down >= 0)
                    {
                        square_down = GameObject.Find($"square X:{x} Y:{down}");
                        config.square_down_old_color = square_down.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color;
                        square_down.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    }
                    if (left >= 0)
                    {
                        square_left = GameObject.Find($"square X:{left} Y:{y}");
                        config.square_left_old_color = square_left.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color;
                        square_left.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                    }
                }
            }
        }
        
    else
    {
        config.activate_buttons = false;
        add_button.GetComponent<Graphic>().color = config.inactive_button;
        remove_button.GetComponent<Graphic>().color = config.inactive_button;
        enter_button.GetComponent<Graphic>().color = config.inactive_button;
        move_units_button.GetComponent<Graphic>().color = config.inactive_button;
    }
}

void move ()
{
    if (selected_object.collider.gameObject.GetComponent<Renderer>().material.color == Color.gray)
    {
        GameObject lsv_move = GameObject.Find($"lsv_units");
        if (lsv_move.transform.position.x == selected_object.transform.position.x && lsv_move.transform.position.z < selected_object.transform.position.z) {
            config.square_up_old_color = config.lsv_color;
            print ("перемещение вверх");
        }
        if ((lsv_move.transform.position.x < selected_object.transform.position.x) && (lsv_move.transform.position.z == selected_object.transform.position.z)) {
            config.square_right_old_color = config.lsv_color;
            print ("перемещение влево");
        }
        if ((lsv_move.transform.position.x == selected_object.transform.position.x) && (lsv_move.transform.position.z > selected_object.transform.position.z)) {
            config.square_down_old_color = config.lsv_color;
            print ("перемещение вниз");
        }
        if ((lsv_move.transform.position.x > selected_object.transform.position.x) && (lsv_move.transform.position.z == selected_object.transform.position.z)) {
            config.square_left_old_color = config.lsv_color;
            print ("перемещение вправо");
        }
        lsv_move.transform.position = new Vector3 (selected_object.transform.position.x, 0, selected_object.transform.position.z);
        
    }
}   

void interaction_with_square ()
{
    if (selected_object.collider.gameObject.name.Contains("square"))
    {
        RaycastHit selected_square = selected_object;

        try {
            old_square.collider.gameObject.GetComponent<Renderer>().material.color = config.old_square_color;
            square_up.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = config.square_up_old_color;
            square_right.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = config.square_right_old_color;
            square_down.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = config.square_down_old_color;
            square_left.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = config.square_left_old_color;
        } 
        catch {}

        config.old_square_color = selected_square.collider.gameObject.GetComponent<Renderer>().material.color;
        old_square = selected_square;

        config.color_square_with_shadow = selected_square.collider.gameObject.GetComponent<Renderer>().material.color - config.square_shadow;
        selected_square.collider.gameObject.GetComponent<Renderer>().material.color = config.color_square_with_shadow;
    }
}                                                              

void Update()
{
    Ray ray = player_camera.ScreenPointToRay(Input.mousePosition);
    if (Input.GetMouseButtonDown(0))
    {
        if (Physics.Raycast(ray, out selected_object))
        {   
            activating_and_deactivating_buttons (); 
            move ();        
            interaction_with_square();
        }
    }    
}
}