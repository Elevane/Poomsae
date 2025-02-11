import React, { useState } from "react";
import { Breadcrumb, Layout, Menu, MenuProps, Skeleton, theme, Typography } from "antd";
import { Link } from 'react-router-dom';
import { useEffect } from "react";
import { ItemType } from "antd/es/menu/interface";
import { useRecoilState } from "recoil";
import { MdOutlineSportsMartialArts } from "react-icons/md";
import userSportsState from "../../state/userSportsState";
import useSportService from "../../Hooks/Services/useSportService";
import { SubChildEntity } from "../../Models/SportsModels";
import HeaderFragment from "../Fragments/HeaderFragment";
import AppLayout from "../Fragments/Generic/AppLayout";

const { Content, Footer, Sider } = Layout;

export interface SportsPageBaseProps {
    children?: React.ReactNode
}

const Dashboard: React.FC<SportsPageBaseProps> = ({ children }) => {
    //const [sports, setSports] = useRecoilState(userSportsState) 
    const [menuItems, setMenuItems] = useState<ItemType[]>([])
    const [sports,] = useRecoilState(userSportsState)
    const sportService = useSportService()

    const getIconByDepth = (depth: number) => {
        switch (depth) {
            case 0: return <MdOutlineSportsMartialArts />; // Sport

            default: return null; // Icône par défaut
        }
    };

    useEffect(() => {
        sportService.getSports(1);
    }, [])

    useEffect(() => {
        if (sports) {


            const buildMenuItems = (entities: SubChildEntity[], depth = 0): ItemType[] => {
                return entities.map((entity, index) => ({
                    key: `${depth}-${index}`,
                    label: entity.name ?? <Typography>{entity.bodyPart}</Typography>,
                    icon: getIconByDepth(depth),
                    children: entity.subChildEntityList ? buildMenuItems(entity.subChildEntityList, depth + 1) : undefined
                }));
            };

            setMenuItems(buildMenuItems(sports));
        }
    }, [sports]);


    const skeletonItems: MenuProps["items"] = new Array(4).fill(null).map((_, index) => ({
        key: `skeleton-${index}`,
        label: <Skeleton.Button active size="small" style={{ width: "80vh" }} />,
        disabled: true, // Empêche l'interaction avec le menu pendant le chargement
    }));

    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();


    return (
        <AppLayout>
            <HeaderFragment />
            <Content style={{ padding: '0 48px' }}>

                {menuItems.length > 0 ?
                    <Breadcrumb style={{ margin: '16px 0' }}><Breadcrumb.Item>Home</Breadcrumb.Item>
                        <Breadcrumb.Item>Sports</Breadcrumb.Item>
                        <Breadcrumb.Item>App</Breadcrumb.Item></Breadcrumb>
                    :
                    <><Skeleton.Button active size="small" style={{ width: "5vh", margin: "10px" }} />
                        <Skeleton.Button active size="small" style={{ width: "5vh", margin: "10px" }} />
                        <Skeleton.Button active size="small" style={{ width: "5vh", margin: "10px" }} /></>
                }

                <Layout
                    style={{ padding: '24px 0', minHeight: "80vh", background: colorBgContainer, borderRadius: borderRadiusLG }}
                >
                    <Sider style={{ background: colorBgContainer }} width={200}>
                        <Menu
                            mode="inline"
                            items={menuItems.length > 0 ? menuItems : skeletonItems}
                        />
                    </Sider>
                    <Content style={{ padding: '0 24px', minHeight: 280 }}>{children}</Content>
                </Layout>
            </Content>
            <Footer style={{ textAlign: 'center' }}>
                Poomsae �{new Date().getFullYear()} Created by  <Link to="https://github.com/Elevane" target="_blank">AUBRY Bastien</Link>
            </Footer>
        </AppLayout>
    );
};

export default Dashboard;