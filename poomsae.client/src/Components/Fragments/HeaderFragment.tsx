import { Menu, MenuProps } from "antd";
import { Header } from "antd/es/layout/layout";
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import { Link, useLocation, useNavigate } from "react-router";
import Logo from "../Atoms/Logo";

const pages = ['hub', 'learn', 'account'];

const HeaderFragment: React.FC = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const [pageIndex, setPageIndex] = useState<string>("hub");

    const menuItems: MenuProps['items'] = pages.map((name, key) => ({
        key: String(key),
        label: name.charAt(0).toUpperCase() + name.slice(1),
        onClick: () => navigate(`/${name}`)
    }));

    useEffect(() => {
        const page = location.pathname.split("/")[1];
        const newPageIndex = pages.findIndex(p => p === page);
        if (`${newPageIndex}` !== pageIndex) {
            setPageIndex(`${newPageIndex}`);
        }
    }, [location.pathname, pageIndex]);

    return (
        <Header style={{ display: 'flex', alignItems: 'center', justifyContent: "space-between" }}>
            <Title level={1} style={{ fontFamily: "Nunito, serif", color: "White", display: "flex", alignItems: "center" }}>
                <span >P</span>
                <span style={{ color: "rgb(206, 17, 38)" }}>o</span>
                <span style={{ color: "rgb(0, 56, 168)" }}>o</span>
                <span >m</span>
                <span >s</span>
                <span >a</span>
                <span >e</span></Title>
            <Menu
                theme="dark"
                mode="horizontal"
                selectedKeys={[pageIndex ?? "0"]}
                items={menuItems}
                style={{ flex: 1, display: 'flex', alignItems: 'center', justifyContent: "flex-start", marginLeft: "5vh" }} />
            <Link to="/logout" style={{ textAlign: "center", color: "white", fontFamily: "Nunito, serif" }}>Disconnect</Link>
        </Header>
    );
}

export default HeaderFragment;