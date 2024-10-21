// Prac W10 Part 3:
// Search functionality to the ReactJS aowebapp application

import React, { useState } from 'react';
import Card from "./CardV3";

function CardListSearch() {

    const [cardData, setState] = useState([]);
    const [query, setQuery] = useState('');
    // Modify the fetch request to use a JS literal/expression that includes the searchText. 
    React.useEffect(() => {
        fetch(`http://localhost:64354/api/itemsWebAPI?searchText=${query}`)
            .then(response => response.json())
            .then(data => setState(data))
            .catch(err => {
                console.log(err);
            });
    }, [query])

    function searchQuery(evt) {
        const value = document.querySelector('[name="searchText"]').value;
        //alert('value: ' + value);
        setQuery(value);
    }

    function handleSubmit(e) {
        // Prevent the browser from reloading the page
        e.preventDefault();

        // Read the form data
        const form = e.target;
        const formData = new FormData(form);
        console.log("FormData: " + formData.get("searchText"));
        setQuery(formData.get("searchText"));

    }
        return (
            // add an input element with textbox and button for performing item name searches.
            <div className="cardListSearch">
                <form method="post" onSubmit={handleSubmit} className="row justify-content-center ">
                    <div className="col-3">
                        <input type="text" name="searchText" className="form-control" placeholder="Type your search..." />
                    </div>
                    <div className="col-3">
                        {/*<button type="button" className="btn btn-primary" onClick={searchQuery}>Search</button>*/}
                        <button type="submit" className="btn btn-outline-primary" value={searchQuery}>Search</button>
                    </div>
                </form>

                <div id="cardList" className="row justify-content-center">
                    {cardData.map((obj) => (
                        <Card
                            key={obj.itemId}
                            itemId={obj.itemId}
                            itemName={obj.itemName}
                            itemDescription={obj.itemDescription}
                            itemImage={obj.itemImage}
                            itemCost={obj.itemCost}
                        />
                    ))}
                </div>
            </div>
        );
}

export default CardListSearch;
