import logo from './logo.svg';
import './App.css';
//import Card from './components/Card';
//import CardV2 from './components/CardV2';
//import CardV3 from './components/CardV3';
//import CardList from './components/CardList';
//import CardListNew from './components/CardListNew';
import CardListSearch from './components/CardListSearch';
//  import the Link component from the react-router-dom library
// can navigate between components / views without the page reloading
import { Link, Outlet } from "react-router-dom";
import CardDetail from './components/CardDetail';
//function App() {
//  return (
//   //Pra10 - 1
//          <div className="App container">
//              <div className="bg-light py-1 mb-2">
//                <h2 className="text-center">Example Application</h2>
//          </div>
//          <div className="row justify-content-center">
//              <Card itemId="1"
//                  itemName="test_record1"
//                  itemDescription="test record1 desc"
//                  itemImage="https://upload.wikimedia.org/wikipedia/commons/0/04/So_happy_smiling_cat.jpg"
//                  itemCost="150.00"
//              />
//              <CardV2 itemId="2"
//                  itemName="test_record2"
//                  itemDescription="test record2 desc"
//                  itemImage="https://upload.wikimedia.org/wikipedia/en/2/2f/Jerry_Mouse.png"
//                  itemCost="50.00"
//              />
//              <CardV3 itemId="3"
//                  itemName="test_record3"
//                  itemDescription="test record3 desc"
//                  itemImage="https://upload.wikimedia.org/wikipedia/en/2/2f/Jerry_Mouse.png"
//                  itemCost="50.00"
//              />
//          </div>
//          </div>
//  );
//}
//Display the CardList
function App() {
    return (
        <div className="App container">
            {/*add navbar*/}
            <nav className="navbar navbar-expand-lg navbar-light" style={{ backgroundColor: '#e3f2fd'}} >
                <div className="container-fluid">
                <Link className="navbar-brand" to="/">AOwebApp</Link>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <div class="navbar-nav">
                            <Link className="nav-link active " to="/Home">Home</Link>
                            <Link className="nav-link " to="/Contact">Contact</Link>
                            <Link className="nav-link " to="/Products">Products</Link>
                        </div>
                    </div>
                </div>
            </nav>
            <Outlet />

            {/* Use CardList here to render multiple cards */}
            {/*<CardList />*/}
            {/*<CardListNew />*/}
            {/*<CardListSearch />*/}
        </div>
    );
}

export default App;
