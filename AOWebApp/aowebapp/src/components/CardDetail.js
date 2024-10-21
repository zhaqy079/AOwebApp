// include the useState and useEffect functions
//Create two new state variables:
//1. cardData and set the default value to an empty object using { }
//2. itemId and set the default value to 1(check this itemId exists in your database, you will use it for testing)
import { useState, useEffect } from "react"
import { Link, useParams } from "react-router-dom";

const CardDetail = ({ }) => {
    // use useParams to extract itemId from the URL
    let params = useParams();

    const [cardData, setState] = useState([]);
    //define a new parameter called "params" and set it to the values returned by the useParams function.
    //This function returns a parameter object with properties that represent each named URL paramete
    //const [itemId, setItemId] = useState(1);
    const [itemId, setItemId] = useState(params.itemId);

    useEffect(() => {
        console.log("useEffect");
        fetch(`http://localhost:64354/api/itemsWebAPI/${itemId}`)
            .then(response => response.json())
            .then(data => setState(data))
            .catch(err => {
                console.log(err);
            });
    }, [itemId])
    return (
        <div className="card col-4 mb-2" style={{ width: 18 + 'rem' }}>
            <img className="card-img-top" src={cardData.itemImage} alt={"Card image:" + cardData.itemName} />
            <div className="card-body">
                <h5 className="card-title">{cardData.itemName}</h5>
                <p className="card-text">{cardData.itemDescription}</p>
                <p className="card-text">{cardData.itemCost}</p>
                <Link to="/Products" className="btn btn-primary">Back to Products</Link>
            </div>
        </div>
    )
}
export default CardDetail;