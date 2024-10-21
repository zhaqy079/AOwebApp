// Prac10-2 declare a new function component
function Card(props) {
    return (
        // Step 1 choose your preferred bootstrap v5 card to display the amazon orders shop items.
        // Step 2 fix up the HTML Card template to use the className attribute
        // since “class” is a reserved word in JavaScript for creating object classes and Reac.js class based components:
        // Note for the style attr in react
        // Add data:start off with basic test data, then move to using a test array followed by JSON retrieved using a fetch request
        // By default, data is passed into functional components via properties or props object
        <div className="card col-4 mb-2" style={{ width: 18 + 'rem' }}>  
            <img className="card-img-top" src={props.itemImage} alt={"Card image:" + props.itemName} />
                <div className="card-body">
                <h5 className="card-title">{props.itemName}</h5>
                <p className="card-text">{props.itemDescription}</p>
                <p className="card-text">{props.itemCost}</p>
                <a href="#" className="btn btn-primary">Go somewhere {props.itemId}</a>
                </div>
        </div>
    );
}

export default Card;