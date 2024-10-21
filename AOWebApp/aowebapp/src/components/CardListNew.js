// Prac W10 Part 2: show all items from the API, fetches data automatically.
// use: useState hook
// then create a useEffect function containing a fetch request to  ItemsWebAPI.
import React, { useState } from 'react'
import Card from "./CardV3"

const CardListNew = ({ }) => {
    
    const [cardData, setState] = useState([]);

    React.useEffect(() => {
        fetch("http://localhost:64354/api/itemsWebAPI")
            .then(response => response.json())
            .then(data => setState(data))
            .catch(err => {
                console.log(err);
            });
    },[])

   
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

export default CardListNew;