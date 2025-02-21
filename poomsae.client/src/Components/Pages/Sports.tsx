import React, { useState } from "react";
import { Breadcrumb, Layout, Menu, theme, Typography } from "antd";
import { useEffect } from "react";
import { ItemType } from "antd/es/menu/interface";
import { MdOutlineSportsMartialArts } from "react-icons/md";
import useSportService from "../../Hooks/Services/useSportService";
import { ParentEntity, SubChildEntity } from "../../Models/SportsModels";
import PageBase from "./Generic/PageBase";
import { useQuery } from "@tanstack/react-query";
import SkeletonMenuItems from "../Molecules/Skeletons/SkeletonMenuItems";
import SkeletonButtonGroup from "../Fragments/SkeletonButtonsGroup";
import { PlusSquareOutlined } from "@ant-design/icons";

const { Content, Sider } = Layout;

export interface SportsPageBaseProps {
    children?: React.ReactNode
}

const Sports: React.FC<SportsPageBaseProps> = ({ children }) => {
    const [menuItems, setMenuItems] = useState<ItemType[]>([])
    const sportService = useSportService()

    const { isPending, data } = useQuery<ParentEntity[]>({
        queryKey: ['sports'],
        queryFn: () => sportService.fetchSports(),
        retryDelay: 10000,
    })

    const getIconByDepth = (depth: number) => {
        switch (depth) {
            case 0: return <MdOutlineSportsMartialArts />; // Sport
            default: return null; // Icône par défaut
        }
    };

    useEffect(() => {
        if (data) {
            const buildMenuItems = (entities: SubChildEntity[], depth = 0): ItemType[] => {
                return entities.map((entity, index) => ({
                    key: `${depth}-${index}`,
                    label: entity.name ?? <Typography>{entity.bodyPart}</Typography>,
                    icon: getIconByDepth(depth),
                    children: entity.subChildEntityList ?
                        [...buildMenuItems(entity.subChildEntityList, depth + 1),
                        { key: `${depth}-${index + 1}`, label: `Add ${entity.name}`, icon: <PlusSquareOutlined />, onClick: () => console.log(`Add ${entity.name}`) }]
                        : undefined
                }));
            };
            setMenuItems(buildMenuItems(data));
        }
        else {
            setMenuItems([{ key: 1, label: `Add Sport`, icon: <PlusSquareOutlined />, onClick: () => console.log(`Add Sport`) }])
        }
    }, [data]);

    const skeletonItems = SkeletonMenuItems(4)

    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();

    return (
        <PageBase>
            <Content style={{ padding: '0 48px' }}>
                {isPending ? <SkeletonButtonGroup count={3} size="small" style={{ margin: '16px 0' }} /> :
                    <Breadcrumb style={{ margin: '16px 0' }}>
                        <Breadcrumb.Item>Sports</Breadcrumb.Item>
                        <Breadcrumb.Item>Sports</Breadcrumb.Item>
                        <Breadcrumb.Item>App</Breadcrumb.Item>
                    </Breadcrumb>


                }
                <Layout
                    style={{ padding: '24px 0', minHeight: "80vh", background: colorBgContainer, borderRadius: borderRadiusLG }}
                >
                    <Sider style={{ background: colorBgContainer }} width={200}>
                        <Menu
                            mode="inline"
                            items={isPending ? skeletonItems : menuItems}
                        />
                    </Sider>
                    <Content style={{ padding: '0 24px', minHeight: 280 }}>{children}</Content>
                </Layout>
            </Content>
        </PageBase>
    );
};

export default Sports;