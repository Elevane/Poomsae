import React from 'react';
import Dashboard from './Components/Pages/DashBoard';
import { BrowserRouter, Route, Routes } from 'react-router';
import Hub from './Components/Pages/Hub';
import { ConfigProvider } from 'antd';
import { RecoilRoot } from 'recoil';
import LoginRegister from './Components/Pages/LoginRegister';
import LoginForm from './Components/Fragments/Forms/LoginForm';
import CreateAccount from './Components/Fragments/Forms/CreateAccountForm';
import NotFound from './Components/Pages/NotFound';
import RequireAuth from './Components/Auth/RequireAuth';
import { Toaster } from 'react-hot-toast';
import ConfirmPassword from './Components/Pages/ConfirmPassword';
import Logout from './Components/Auth/logout';

const theme = {
    token: {
        colorBgBase: "#FFFFFF",
        colorPrimary: "#0047A0",
        colorSecondary: "#CD2E3A",
        tertiaryColor: "#001529"
    }
}
const App: React.FC = () => {

    return (
        <RecoilRoot>
            <Toaster position="bottom-right"></Toaster>
            <ConfigProvider theme={theme}>
                <BrowserRouter>
                    <Routes>
                        <Route path="/login" element={<LoginRegister title="Connexion" child={<LoginForm />} />}></Route>
                        <Route path="/logout" element={<Logout />}></Route>
                        <Route path="/confirm_password/:token" element={<ConfirmPassword />}></Route>
                        <Route path="/create_account" element={<LoginRegister title="Register" child={<CreateAccount />} />}></Route>
                        <Route path="/learn" element={<RequireAuth><Dashboard /></RequireAuth>}></Route>
                        <Route path="/hub" element={<RequireAuth><Hub /></RequireAuth>}></Route>
                        <Route path="*" element={<NotFound />} />
                    </Routes>
                </BrowserRouter>
            </ConfigProvider>
        </RecoilRoot>
    );
};

export default App;