import React from 'react';
import Dashboard from './Components/Pages/DashBoard';
import { Route,  Routes } from 'react-router';
import Hub from './Components/Pages/Hub';


const App: React.FC = () => {

    return (
       
            <Routes>
                <Route path="/learn" element={<Dashboard />}></Route>
                <Route path="/hub" element={<Hub />}></Route>
            </Routes>
        
    );
};

export default App;