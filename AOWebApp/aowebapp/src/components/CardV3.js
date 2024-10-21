// Prac10-2 Alternative method:lambda expressions (=>) for passing property data, 
// set the navigation button to use a ReactJS Link Component
import { Link } from "react-router-dom";

const CardV3 = ({ itemId, itemName, itemDescription, itemCost, itemImage }) => (
        <div className="card col-4 mb-2" style={{ width: 18 + 'rem' }}>
            <img className="card-img-top" src={itemImage} alt={"Card image:" + itemName} />
            <div className="card-body">
                <h5 className="card-title">{itemName}</h5>
                <p className="card-text">{itemDescription}</p>
                <p className="card-text">{itemCost}</p>
            {/*<a href="#" className="btn btn-primary">Go somewhere {itemId}</a>*/}
            {/*set the path to Products/{ItemId}*/}
            <Link to={"/Products/" + itemId} className="btn btn-primary">View Detail</Link>
            </div>
        </div>
    );

export default CardV3;
