import Card from "./CardV3"
import cardData from "../assets/itemData.json"// uses a hardcoded list of items loaded from a static JSON file (itemData.json).

const CardList = ({ }) => {
    // Cardlist using array
    //let cardData = [
    //    { itemId: 1, itemName: "record 1", itemDescription: "record 1 description", itemCost: 15.00, itemImage: "https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg" },

    //    { itemId: 2, itemName: "record 2", itemDescription: "record 2 description", itemCost: 10.00, itemImage: "https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg" },

    //    { itemId: 3, itemName: "record 3", itemDescription: "record 3 description", itemCost: 5.00, itemImage: "https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg" },

    //]
    // Update the CardList component to reference the itemData.json file and refer to it as the cardData

    console.log("cardData: " + cardData)
    return (
        <div className="row justify-content-center">
            {cardData.map((obj) => (
                <Card
                    key={obj.itemId}
                    itemId={obj.itemId}
                    itemName={obj.itemName}
                    itemDescription={obj.itemDescription}
                    itemImage={obj.itemImage}
                    itemCost={obj.itemCost}
                />
            )
            )
            }
        </div>
    )
}

export default CardList;