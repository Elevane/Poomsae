import React from "react";
import { Layout } from "antd";
import { Link } from 'react-router';
import HeaderFragment from "../Fragments/HeaderFragment";
import AppLayout from "../Fragments/Generic/AppLayout";
import Dashboard from "../Fragments/Subpages/Dashboard";

const { Footer, } = Layout;



const Hub: React.FC = () => {
    return (
        <AppLayout>
            <HeaderFragment />
            <Dashboard />
            <Footer style={{
                textAlign: 'center', backgroundColor: "#001529", color: "white",
            }}>
                Poomsae &copy;{new Date().getFullYear()} Created by  <Link to="https://github.com/Elevane" target="_blank">AUBRY Bastien</Link>
            </Footer>
        </AppLayout>
    );
};

export default Hub;