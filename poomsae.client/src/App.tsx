import React from 'react';
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
import Account from './Components/Pages/Account';
import Sports from './Components/Pages/Sports';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import HomePage from './Components/Pages/HomePage';

const theme = {
    token: {
        colorBgBase: "#FFFFFF",
        colorPrimary: "#0047A0",
        colorSecondary: "#CD2E3A",
        tertiaryColor: "#001529",
        colorBgContainer: "#FFFFFF",
    }
}
const App: React.FC = () => {
    const queryClient = new QueryClient()
    return (
        <QueryClientProvider client={queryClient}>
            <RecoilRoot>
                <Toaster position="bottom-right"></Toaster>
                <ConfigProvider theme={theme}>
                    <BrowserRouter>
                        <Routes>
                            <Route path="/" element={<HomePage />}></Route>
                            <Route path="/login" element={<LoginRegister title="Connexion" child={<LoginForm />} />}></Route>
                            <Route path="/logout" element={<Logout />}></Route>
                            <Route path="/confirm_password/:token" element={<ConfirmPassword />}></Route>
                            <Route path="/create_account" element={<LoginRegister title="Register" child={<CreateAccount />} />}></Route>
                            <Route path="/learn" element={<RequireAuth><Sports /></RequireAuth>}></Route>
                            <Route path="/account" element={<RequireAuth><Account /></RequireAuth>}></Route>
                            <Route path="/hub" element={<RequireAuth><Hub /></RequireAuth>}></Route>
                            <Route path="*" element={<NotFound />} />
                        </Routes>
                    </BrowserRouter>
                </ConfigProvider>
            </RecoilRoot>
        </QueryClientProvider>
    );
};

export default App;