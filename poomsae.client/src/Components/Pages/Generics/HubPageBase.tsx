import React from "react";
import { Layout } from "antd";
import { Link } from 'react-router';
import HeaderFragment from "../../Fragments/HeaderFragment";

const {  Footer,  } = Layout;

export interface HubPageBaseProps {
    children?: React.ReactNode
}

const HubPageBase: React.FC<HubPageBaseProps> = ({ children }) => {

    return (
        <Layout className="app">
            <HeaderFragment />

            Hub{children}
            <Footer style={{ textAlign: 'center' }}>
                Poomsae �{new Date().getFullYear()} Created by  <Link to="https://github.com/Elevane" target="_blank">AUBRY Bastien</Link>
            </Footer>
        </Layout>
    );
};

export default HubPageBase;