import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
// Firstly install the react router:npm install react - router - dom@6
// Add new route element component
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./routes/Home";
import Contact from "./routes/Contact";
import CardListSearch from './components/CardListSearch';
import CardDetail from './components/CardDetail';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        {/*modify the Index.js file to include the BrowserRouter component.*/}
        <BrowserRouter>
            {/*<App />  directly and then nested routes inside it,*/}
            <Routes>
                {/* Route for the main App component, nesting the routes inside <App /> using React Router's layout approach*/}
                <Route path="/" element={<App />} >
                    {/*A Route with an empty path that loads to Home Component*/}
                    {/*<Route path="/" element={<Home />} />*/}
                    {/*A Route that matches "Home" and loads the Home Component*/}
                    <Route path="Home" element={<Home />} />
                    {/*A Route that matches "Contact" and loads the Contact Component*/}
                    <Route path="Contact" element={<Contact />} />
                    {/*A Route that matches "Products" and loads the CardListSearch component*/}
                    <Route path="Products" element={<CardListSearch />} />
                    {/*pass the Id of the selected item to the CardDetail*/}
                    <Route path="Products/:itemId" element={<CardDetail />} />
                    <Route path="" element={<Home />} />
                    <Route path="*" element={<Home />} />
                </Route>
            </Routes>
        </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
