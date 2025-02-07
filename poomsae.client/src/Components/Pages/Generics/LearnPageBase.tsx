import React from "react";
import { Breadcrumb, Layout, Menu, MenuProps, theme } from "antd";
import { LaptopOutlined, NotificationOutlined, UserOutlined } from '@ant-design/icons';
import { Link } from 'react-router';
import HeaderFragment from "../../Fragments/HeaderFragment";

const {  Content, Footer, Sider } = Layout;


const items2: MenuProps['items'] = [UserOutlined, LaptopOutlined, NotificationOutlined].map(
    (icon, index) => {
        const key = String(index + 1);

        return {
            key: `sub${key}`,
            icon: React.createElement(icon),
            label: `subnav ${key}`,

            children: new Array(4).fill(null).map((_, j) => {
                const subKey = index * 4 + j + 1;
                return {
                    key: subKey,
                    label: `option${subKey}`,
                };
            }),
        };
    },
);
export interface SportsPageBaseProps {
    children: React.ReactNode
}

const LearnPageBase: React.FC<SportsPageBaseProps> = ({ children }) => {

    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();


    return (
        <Layout className="app">
            <HeaderFragment />
                <Content style={{ padding: '0 48px' }}>
                    <Breadcrumb style={{ margin: '16px 0' }}>
                        <Breadcrumb.Item>Home</Breadcrumb.Item>
                        <Breadcrumb.Item>Sports</Breadcrumb.Item>
                        <Breadcrumb.Item>App</Breadcrumb.Item>
                    </Breadcrumb>
                    <Layout
                        style={{ padding: '24px 0', minHeight: "80vh", background: colorBgContainer, borderRadius: borderRadiusLG }}
                    >
                        <Sider style={{ background: colorBgContainer }} width={200}>
                            <Menu
                                mode="inline"
                                items={items2}
                            />
                        </Sider>
                    <Content style={{ padding: '0 24px', minHeight: 280 }}>{children}</Content>
                    </Layout>
                </Content>
            <Footer style={{ textAlign: 'center' }}>
                Poomsae �{new Date().getFullYear()} Created by  <Link to="https://github.com/Elevane" target="_blank">AUBRY Bastien</Link>
                </Footer>
            </Layout>
    );
};

export default LearnPageBase;