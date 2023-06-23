using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemslot : MonoBehaviour
{
    public Transform detallesobjeto; 
    public Item item=null;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform inventario=gameObject.transform.parent.GetComponent<RectTransform>();
        detallesobjeto=inventario.Find("detalles objeto");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown(){
        if(!object.ReferenceEquals(item, null)){
            detallesobjeto.Find("Layout vertical/Nombre objeto").GetComponent<TMPro.TextMeshPro>().text=item.nombre;
            detallesobjeto.Find("Layout vertical/Iconoobjeto/spriteobjeto").GetComponent<SpriteRenderer>().sprite=item.icono;
            detallesobjeto.Find("Layout vertical/Descripcionobjeto").GetComponent<TMPro.TextMeshPro>().text=item.descripcion;
            detallesobjeto.gameObject.SetActive(true);
        }
    }
}
