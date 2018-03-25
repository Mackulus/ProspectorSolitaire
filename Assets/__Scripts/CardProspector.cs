using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// This is an enum, which defines a type of variable that only has a few
// possible named values. The CardState variable type has one of four values:
// drawpile, tableau, target, & discard
public enum CardState
{
    drawpile,
	toDrawpile,
    tableau,
    target,
	toTarget,
    discard,
	toDiscard,
	to,
	idle
}
public class CardProspector : Card
{ // Make sure CardProspector extends Card

	static public float moveDuration = 0.5f;
	static public string moveEasing = Easing.InOut;
    // This is how you use the enum CardState
    public CardState state = CardState.drawpile;
    // The hiddenBy list stores which other cards will keep this one face down
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    // LayoutID matches this card to a Layout XML id if it's a tableau card
    public int layoutID;
    // The SlotDef class stores information pulled in from the LayoutXML <slot>
    public SlotDef slotDef;

	public List<Vector3> bezierPts;
	public float timeStart, timeDuration;

	public GameObject reportFinishTo = null;

	public void MoveTo(Vector3 pos)
	{
		bezierPts = new List<Vector3>();
		bezierPts.Add (transform.localPosition);
		bezierPts.Add (pos);

		if (timeStart == 0)
		{
			timeStart = Time.time;
		}

		timeDuration = moveDuration;

		state = CardState.to;
	}

    // This allows the card to react to being clicked
    override public void OnMouseUpAsButton()
    {
        // Call the CardClicked method on the Prospector singleton
        Prospector.S.CardClicked(this);
        // Also call the base class (Card.cs) version of this method
        base.OnMouseUpAsButton();
    }

	void Update()
	{
		switch(state)
		{
		case CardState.toDrawpile:
		case CardState.toTarget:
		case CardState.toDiscard:
		case CardState.to:
			float u = (Time.time - timeStart)/timeDuration;
			float uC = Easing.Ease (u, moveEasing);

			if (u < 0)
			{
				transform.localPosition = bezierPts[0];
				return;
			}
			else if (u >= 1)
			{
				uC = 1;
				if (state == CardState.toDrawpile) state = CardState.drawpile;
				if (state == CardState.toTarget) state = CardState.target;
				if (state == CardState.toDiscard) state = CardState.discard;
				if (state == CardState.to) state = CardState.idle;

				transform.localPosition = bezierPts[bezierPts.Count - 1];

				timeStart = 0;

				if (reportFinishTo != null)
				{
					reportFinishTo.SendMessage("CBCallback", this);
					reportFinishTo = null;
				}
				else
				{}
			}
			else
			{
				Vector3 pos = Utils.Bezier(uC, bezierPts);
				transform.localPosition = pos;
			}
			break;
		}
	}

}

