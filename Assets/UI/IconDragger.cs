using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IconDragger : MouseManipulator
{
    Controller controller;

    private Vector2 startPos;
    private Vector2 elemStartPosGlobal;
    private Vector2 elemStartPosLocal;

    VisualElement dragArea;
    VisualElement iconContainer;
    VisualElement dropZone;

    bool isActive;

    public IconDragger(VisualElement root, Controller controller)
    {   
        this.controller = controller;

        dragArea = root.Q("DragArea");
        dropZone = root.Q("DropBox");

        isActive = false;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }


    protected override void UnregisterCallbacksFromTarget()
    {
        target.RegisterCallback<MouseDownEvent>(OnMouseDown);
        target.RegisterCallback<MouseMoveEvent>(OnMouseMove);
        target.RegisterCallback<MouseUpEvent>(OnMouseUp);
    }

    protected void OnMouseDown(MouseDownEvent e)
    {   
        //pobierz odniesienie do kontenera z ikonami na pozniej
        iconContainer = target.parent;

        // pobierz pozycje startowa myszy
        startPos = e.localMousePosition;

        //pobierz obie pozycje obiektu
        elemStartPosGlobal = target.worldBound.position;
        elemStartPosLocal = target.layout.position;

        // wlacz dragArea
        dragArea.style.display = DisplayStyle.Flex;
        dragArea.Add(target);

        //popraw pozycje po przepozycjonowaniu
        target.style.top = elemStartPosGlobal.y;
        target.style.left = elemStartPosGlobal.x;

        isActive = true;
        target.CaptureMouse();
        e.StopPropagation();

    }

    protected void OnMouseMove(MouseMoveEvent e)
    {
        if (!isActive || !target.HasMouseCapture())
            return;

        Vector2 diff = e.localMousePosition - startPos;

        target.style.top = target.layout.y + diff.y;
        target.style.left = target.layout.x + diff.x;

        e.StopPropagation();
    }

    protected void OnMouseUp(MouseUpEvent e) 
    {
        if (!isActive || !target.HasMouseCapture())
            return;

        if (target.worldBound.Overlaps(dropZone.worldBound))
        {
            dropZone.Add(target);

            target.style.top = dropZone.contentRect.center.y - target.layout.height / 2;
            target.style.left = dropZone.contentRect.center.x - target.layout.width / 2;

            // Debug.Log("W bezpiecznej strefie!");

            Debug.Log("Podana odpowiedz to: " + ((Question)target.userData).display_name);

            controller.CheckAnswer(((Question)target.userData).answer);
        }
        else
        {
            iconContainer.Add(target);

            target.style.top = elemStartPosLocal.y - iconContainer.contentRect.position.y; //odejmujemy ramke do poprawy pozycji
            target.style.left = elemStartPosLocal.x - iconContainer.contentRect.position.x; //to samo

        }


        isActive = false;
        target.ReleaseMouse();
        e.StopPropagation();

        dragArea.style.display = DisplayStyle.None;

    }

}
