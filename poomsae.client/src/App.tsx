import React from 'react';
import Dashboard from './Components/Pages/DashBoard';
import { BrowserRouter, Route, Routes } from 'react-router';
import Hub from './Components/Pages/Hub';
import { ConfigProvider } from 'antd';
import { RecoilRoot } from 'recoil';
import LoginRegister from './Components/Pages/LoginRegister';
import LoginForm from './Components/Fragments/Forms/LoginForm';
import CreateAccount from './Components/Fragments/Forms/CreateAccountForm';


const App: React.FC = () => {

    return (
        <RecoilRoot>
            <ConfigProvider theme={{}}>
                <BrowserRouter>
                    <Routes>
                        <Route path="/login" element={<LoginRegister title="Connexion" child={<LoginForm />} />}></Route>
                        <Route path="/create_account" element={<LoginRegister title="Register" child={<CreateAccount />} />}></Route>
                        <Route path="/learn" element={<Dashboard />}></Route>
                        <Route path="/hub" element={<Hub />}></Route>
                    </Routes>
                </BrowserRouter>
            </ConfigProvider>
        </RecoilRoot>
    );
};

export default App;