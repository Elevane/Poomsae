import React from 'react';
import Dashboard from './Components/Pages/DashBoard';
import Home from './Components/Pages/Generics/SportsPageBase';
import { Route, Router, Routes } from 'react-router';


const App: React.FC = () => {

    return (
       
            <Routes>
                <Route path="/" element={<Dashboard />}></Route>
            </Routes>
        
    );
};

export default App;