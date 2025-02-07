import React from 'react';
import Dashboard from './Components/Pages/DashBoard';
import { Route,  Routes } from 'react-router';
import Hub from './Components/Pages/Hub';
import { ConfigProvider } from 'antd';
import { RecoilRoot } from 'recoil';


const App: React.FC = () => {

    return (
        <RecoilRoot>
       <ConfigProvider theme={{}}>
            <Routes>
                <Route path="/learn" element={<Dashboard />}></Route>
                <Route path="/hub" element={<Hub />}></Route>
            </Routes>
        </ConfigProvider>
        </RecoilRoot>
    );
};

export default App;