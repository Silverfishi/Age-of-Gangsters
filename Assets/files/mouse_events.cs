using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse_events: MonoBehaviour

{


    Camera _camera;

    public GameObject lsv_unit_prefab;

    public Color square_color;
    public bool activate_buttons;

    public Color inactive_button;
    public Color add_button_activate;
    public Color remove_button_activate;
    public Color enter_button_activate;
    public Color move_units_button_activate;

    public GameObject add_button;
    public GameObject remove_button;
    public GameObject enter_button;
    public GameObject move_units_button;

    public Color square_shadow;                
    public Color color_square_with_shadow;     
    public Color old_square_color;            
    public RaycastHit old_square;            
    public bool start_checking_color;      
                     
    public RaycastHit selected_object;       

    void Start() {
        _camera = Camera.main;                        

        activate_buttons = false;
        inactive_button = new Color(0.5f, 0.5f, 0.5f);
        add_button_activate = new Color(0.4f, 0.9f, 0.4f);
        remove_button_activate = new Color(0.9f, 0.4f, 0.4f);
        enter_button_activate = new Color(0.4f, 0.4f, 0.9f);
        move_units_button_activate = new Color(0.5f, 0.5f, 0.9f);

        square_shadow = new Color(0.1F, 0.1F, 0.1F);   
        start_checking_color = false;                 
    }


     void activating_and_deactivating_buttons () {
        square_color = selected_object.collider.gameObject.GetComponent<Renderer>().material.color;
        if (square_color == intercept_the_square.lsv_color || square_color == intercept_the_square.lsv_color - square_shadow)
        {
            activate_buttons = true;
            add_button.GetComponent<Graphic>().color = add_button_activate;
            remove_button.GetComponent<Graphic>().color = remove_button_activate;
            enter_button.GetComponent<Graphic>().color = enter_button_activate;
            move_units_button.GetComponent<Graphic>().color = move_units_button_activate;
        }
        else if (activate_buttons && selected_object.collider.gameObject.name == "add_button")
        {
            unit_spawner.lsv_units[0] += 10;
            Instantiate(lsv_unit_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (activate_buttons && selected_object.collider.gameObject.name == "remove_button")
            unit_spawner.lsv_units[0] -= 10;
        else if (activate_buttons && selected_object.collider.gameObject.name == "move_button")
        {
            for (int x=0; x<=7; x++)
            {
                for (int y=0; y<=7; y++)
                {
                    if (old_square.collider.gameObject.name == $"square X:{x} Y:{y}")
                    {
                        if (y + 1 <= 7)
                        {
                            GameObject square_up = GameObject.Find($"square X:{x} Y:{y + 1}");
                            square_up.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                        }
                        if (x+1 <= 7)
                        {
                            GameObject square_right = GameObject.Find($"square X:{x + 1} Y:{y}");
                            square_right.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                        }
                        if (y - 1 >= 0)
                        { 
                            GameObject square_down = GameObject.Find($"square X:{x} Y:{y - 1}");
                            square_down.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                        }
                        if (x - 1 >= 0)
                        {
                            GameObject square_left = GameObject.Find($"square X:{x - 1} Y:{y}");
                            square_left.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.gray;
                        }
                    }
                }
            }
        }
        else
        {
            activate_buttons = false;
            add_button.GetComponent<Graphic>().color = inactive_button;
            remove_button.GetComponent<Graphic>().color = inactive_button;
            enter_button.GetComponent<Graphic>().color = inactive_button;
            move_units_button.GetComponent<Graphic>().color = inactive_button;
        }
    }

    void interaction_with_buttons ()
    {            
        if (selected_object.collider.gameObject.GetComponent<Renderer>().material.color == Color.gray)
        {
            GameObject lsv_move = GameObject.Find($"lsv_units(Clone)");
            lsv_move.transform.position = new Vector3 (selected_object.transform.position.x, 0, selected_object.transform.position.z);
        }
    }   

    void interaction_with_square ()
    {
            if (selected_object.collider.gameObject.name.Contains("square"))
            {
                RaycastHit selected_square = selected_object;
                if (start_checking_color)
                    old_square.collider.gameObject.GetComponent<Renderer>().material.color = old_square_color;
                else
                    start_checking_color = true;

                old_square_color = selected_square.collider.gameObject.GetComponent<Renderer>().material.color;
                old_square = selected_square;

                color_square_with_shadow = selected_square.collider.gameObject.GetComponent<Renderer>().material.color - square_shadow;
                selected_square.collider.gameObject.GetComponent<Renderer>().material.color = color_square_with_shadow;
            }
    }                                                              

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out selected_object))
            {   
                activating_and_deactivating_buttons ();
                interaction_with_buttons();                         
                interaction_with_square();
            }
        }    
    }
}