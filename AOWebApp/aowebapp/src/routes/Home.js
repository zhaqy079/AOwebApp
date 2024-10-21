import React from 'react';
import CardList from '../components/CardList'
//import CardListNew from '../components/CardListNew'; // Notes for the path 

function Home() {
    return (
        <div className="bg-light py-1 mb-2">
            <h2 className="row justify-content-center">Home Page</h2>
            {/*Display the card list info*/}
            <CardList />
            {/*<CardListNew />*/}
        </div>
    );
}

export default Home; 
