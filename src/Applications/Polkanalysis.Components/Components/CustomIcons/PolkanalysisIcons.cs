﻿using Microsoft.FluentUI.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Components.CustomIcons
{
    public static class PolkanalysisIcons
    {
        public static class PolkadotIcons
        {
            public class AccountPortability : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"24\" height=\"24\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1.5\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M8 13.7644L2 13.7644\"></path><path d=\"M6.16985 16.6807L9.08611 13.7643L6.16985 10.848\" fill=\"none\"></path><path d=\"M19.6117 14.6402L20.3804 13.716C21.6924 12.1387 21.5873 9.82174 20.1379 8.36968C18.5861 6.81497 16.067 6.81497 14.5152 8.36968C13.0658 9.82174 12.9608 12.1387 14.2727 13.716L15.0413 14.64C15.5323 15.2302 15.251 16.1304 14.5113 16.3361L13.47 16.6257C10.6189 17.4185 8.64612 20.0149 8.64612 22.9741V25.8286H26V22.9692C26 20.0124 24.0291 17.4182 21.1806 16.6255L20.1415 16.3363C19.402 16.1305 19.1208 15.2304 19.6117 14.6402Z\"></path></svg>";

                public AccountPortability() : base("AccountPortability", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class BlockExplorer : Icon
            {
                private const string SVG_CONTENT = "<svg viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1.5\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><rect x=\"4\" y=\"2\" width=\"20\" height=\"24\"></rect><path d=\"M19.4584 8.33936L11.9206 8.33936M8.43256 8.33936L8.42177 8.33936\"></path><path d=\"M19.4584 13.75L11.9206 13.75M8.43256 13.75L8.42177 13.75\"></path><path d=\"M19.4584 19.3394L11.9206 19.3394M8.43256 19.3394L8.42177 19.3394\"></path></svg>";

                public BlockExplorer() : base("BlockExplorer", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class BlockNumber : Icon
            {
                private const string SVG_CONTENT = "<svg viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M2 14.4276H4.57235\"></path><path d=\"M23.4277 14.4276H26\"></path><path d=\"M23.4277 5H4.57235V23.8553H23.4277V5Z\"></path><path d=\"M11.8745 10.114L11.8745 18.599\" stroke-miterlimit=\"10\"></path><path d=\"M16.1651 10.114L16.1651 18.599\" stroke-miterlimit=\"10\"></path><path d=\"M18.2623 12.2115L9.77731 12.2115\" stroke-miterlimit=\"10\"></path><path d=\"M18.2623 16.5021L9.77731 16.5021\" stroke-miterlimit=\"10\"></path></svg>";

                public BlockNumber() : base("BlockNumber", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Extrinsic : Icon
            {
                private const string SVG_CONTENT = "<svg viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M2 16.5029H26V20.5H2V16.5029Z\"></path><path d=\"M2 2.5H26V16.5029H2V2.5Z\"></path><path d=\"M10 25H18\"></path><path d=\"M14 24.5L14 20.5\"></path></svg>";

                public Extrinsic() : base("Extrinsic", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Event : Icon
            {
                private const string SVG_CONTENT = "<svg viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><g><path d=\"M18.6289 26H2V3.88454H26V18.9448L18.6289 26Z\" stroke-miterlimit=\"10\"></path><path d=\"M9.42334 6.34171V2\" stroke-miterlimit=\"10\"></path><path d=\"M18.5764 6.34178V2.00008\" stroke-miterlimit=\"10\"></path><path d=\"M2.10101 11.2501H26\" stroke-miterlimit=\"10\"></path><path d=\"M18.4785 25.2163V18.4537H25.6592\" stroke-miterlimit=\"10\"></path></g></svg>";

                public Event() : base("Event", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Runtime : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M9.36649 24.4503C15.3574 26.7917 22.1118 23.8339 24.4529 17.8438C26.7939 11.8537 23.8351 5.09971 17.8442 2.75833C11.8533 0.416941 5.09886 3.3748 2.75781 9.36488C0.416752 15.355 3.37556 22.109 9.36649 24.4503Z\"></path><path d=\"M10.3107 13.9197L12.2736 10.8418M16.7663 13.5669L15.2206 10.8713M15.4945 16.4535L12.1033 16.4399\"></path><path d=\"M17.3645 18.9673C18.7605 19.5136 20.3365 18.8183 20.8845 17.4143C21.4325 16.0104 20.7451 14.4294 19.3491 13.8832C17.9531 13.3369 16.3771 14.0322 15.8291 15.4362C15.2811 16.8401 15.9685 18.4211 17.3645 18.9673Z\"></path><path d=\"M7.81566 19.0113C9.21166 19.5575 10.7876 18.8622 11.3356 17.4583C11.8837 16.0543 11.1962 14.4734 9.80024 13.9271C8.40424 13.3809 6.82829 14.0762 6.28026 15.4801C5.73223 16.8841 6.41965 18.465 7.81566 19.0113Z\"></path><path d=\"M12.7483 11.014C14.1443 11.5603 15.7203 10.865 16.2683 9.46104C16.8163 8.05709 16.1289 6.47614 14.7329 5.92989C13.3369 5.38364 11.761 6.07893 11.2129 7.48288C10.6649 8.88683 11.3523 10.4678 12.7483 11.014Z\"></path></svg>";

                public Runtime() : base("Runtime", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Modules : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M11.4052 9.67229C12.9211 11.1883 15.379 11.1883 16.895 9.67229C18.411 8.15631 18.411 5.69841 16.895 4.18243C15.379 2.66645 12.9211 2.66645 11.4052 4.18243C9.88917 5.69841 9.88917 8.15631 11.4052 9.67229Z\"></path><path d=\"M21.8326 20.2595L18.6832 15.6744\"></path><path d=\"M9.3056 15.6887L6.11505 20.2453\"></path><path d=\"M20.7082 22.5502C20.7082 24.1448 22.0009 25.4375 23.5955 25.4375C25.1901 25.4375 26.4828 24.1448 26.4828 22.5502C26.4828 20.9555 25.1901 19.6628 23.5955 19.6628C22.0009 19.6628 20.7082 20.9555 20.7082 22.5502Z\"></path><path d=\"M1.4826 22.5502C1.4826 24.1448 2.7753 25.4375 4.36993 25.4375C5.96456 25.4375 7.25726 24.1448 7.25726 22.5502C7.25726 20.9555 5.96456 19.6628 4.36993 19.6628C2.7753 19.6628 1.4826 20.9555 1.4826 22.5502Z\"></path></svg>";

                public Modules() : base("Modules", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Staking : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M25 12.958V16C25 20.0501 20.0751 22.875 14 22.875C7.92487 22.875 3 20.0501 3 16V12.958\"></path><path d=\"M14 19.6667C20.0751 19.6667 25 16.3834 25 12.3333C25 8.28325 20.0751 5 14 5C7.92487 5 3 8.28325 3 12.3333C3 16.3834 7.92487 19.6667 14 19.6667Z\"></path><path d=\"M11 13.5335L14.178 15.9725L17.356 13.5335\"></path><path d=\"M14.1998 15.203L14.1998 9\"></path></svg>";

                public Staking() : base("Staking", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Pools : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 26\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M19.8885 11.3879C23.3217 11.3879 26.1049 14.1711 26.1049 17.6043C26.1049 21.0375 23.3217 23.8207 19.8885 23.8207C17.3384 23.8207 15.1469 22.2851 14.1882 20.0882\" stroke-miterlimit=\"10\"></path><path d=\"M13.8626 15C14.2286 15.7922 14.4328 16.6744 14.4328 17.6044C14.4328 21.0376 11.6496 23.8208 8.21643 23.8208C4.78322 23.8208 2.00006 21.0376 2.00006 17.6044C2.00006 14.2107 4.71949 11.4522 8.09809 11.3891\" stroke-miterlimit=\"10\"></path><path d=\"M13.9888 14.4327C17.422 14.4327 20.2051 11.6496 20.2051 8.21637C20.2051 4.78316 17.422 2 13.9888 2C10.5556 2 7.7724 4.78316 7.7724 8.21637C7.7724 11.6496 10.5556 14.4327 13.9888 14.4327Z\" stroke-miterlimit=\"10\"></path></svg>";

                public Pools() : base("Pools", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Validators : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><g><path d=\"M14 26C20.6274 26 26 20.6274 26 14C26 7.37258 20.6274 2 14 2C7.37258 2 2 7.37258 2 14C2 20.6274 7.37258 26 14 26Z\"></path><path d=\"M8.03863 14.0733L13.0614 18.697L25.3774 2.42365\" fill=\"none\" data-nofill=\"true\"></path></g></svg>";

                public Validators() : base("Validators", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Nominators : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M21.4273 6.57269H2V26H21.4273V6.57269Z\"></path><path d=\"M7.11935 14.0187L12.3012 18.7889L25.0074 2\" fill=\"none\" data-nofill=\"true\"></path></svg>";

                public Nominators() : base("Nominators", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Dex : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"24\" height=\"24\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1.5\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><g><path d=\"M14.0019 7.54055C15.5315 7.54055 16.7715 6.30026 16.7715 4.77028C16.7715 3.24029 15.5315 2 14.0019 2C12.4723 2 11.2323 3.24029 11.2323 4.77028C11.2323 6.30026 12.4723 7.54055 14.0019 7.54055Z\"></path><path d=\"M7.47419 25.9903C9.00379 25.9903 10.2438 24.7501 10.2438 23.2201C10.2438 21.6901 9.00379 20.4498 7.47419 20.4498C5.94458 20.4498 4.70459 21.6901 4.70459 23.2201C4.70459 24.7501 5.94458 25.9903 7.47419 25.9903Z\"></path><path d=\"M4.7696 14.9279C6.2992 14.9279 7.53919 13.6876 7.53919 12.1576C7.53919 10.6277 6.2992 9.38736 4.7696 9.38736C3.23999 9.38736 2 10.6277 2 12.1576C2 13.6876 3.23999 14.9279 4.7696 14.9279Z\"></path><path d=\"M23.2332 14.9279C24.7628 14.9279 26.0028 13.6876 26.0028 12.1576C26.0028 10.6277 24.7628 9.38736 23.2332 9.38736C21.7036 9.38736 20.4636 10.6277 20.4636 12.1576C20.4636 13.6876 21.7036 14.9279 23.2332 14.9279Z\"></path><path d=\"M20.4551 26C21.9847 26 23.2247 24.7597 23.2247 23.2297C23.2247 21.6997 21.9847 20.4594 20.4551 20.4594C18.9255 20.4594 17.6855 21.6997 17.6855 23.2297C17.6855 24.7597 18.9255 26 20.4551 26Z\"></path><path d=\"M10.237 23.4129H17.6855\"></path><path d=\"M7.02393 10.4565L11.3117 6.16761\"></path><path d=\"M20.9597 10.4413L16.616 6.09658\"></path><path d=\"M21.2394 20.5684L22.7864 14.891\"></path><path d=\"M6.69489 20.561L5.16279 14.9059\"></path></g></svg>";

                public Dex() : base("Dex", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Parachains : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><rect x=\"6\" y=\"6\" width=\"16\" height=\"16\"></rect><path d=\"M14 2L14 6\"></path><path d=\"M10 2L10 6\"></path><path d=\"M18 2L18 6\"></path><path d=\"M14 22L14 26\"></path><path d=\"M18 14.1738V13.8259C18 11.6168 16.2091 9.82593 14 9.82593C11.7909 9.82593 10 11.6168 10 13.8259V14.1738C10 16.3829 11.7909 18.1738 14 18.1738C16.2091 18.1738 18 16.3829 18 14.1738Z\"></path></svg>";

                public Parachains() : base("Parachains", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Auctions : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><g><path d=\"M17.2186 1.99999L6.34143 12.8772L11.78 18.3158L22.6572 7.43859L17.2186 1.99999Z\" stroke-miterlimit=\"10\"></path><path d=\"M18.5783 11.5176L15.859 14.2369L23.2641 21.6421L25.9834 18.9228L18.5783 11.5176Z\" stroke-miterlimit=\"10\"></path><path d=\"M14.4984 26L2 26\" stroke-miterlimit=\"10\"></path><path d=\"M12.5756 22.6308L3.92285 22.6308\" stroke-miterlimit=\"10\"></path></g></svg>";

                public Auctions() : base("Auctions", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Crowdloans : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><g><path d=\"M25.8173 25.8292L22 22.022M21.476 25.1348L21.464 21.4874L25.115 21.4754\" stroke-miterlimit=\"10\"></path><path d=\"M25.8173 2.17082L21.9881 6M21.476 2.86516L21.464 6.51259L25.115 6.52456\" stroke-miterlimit=\"10\"></path><path d=\"M2.18269 25.8292L5.97493 22.047M6.52398 25.1348L6.53597 21.4874L2.88498 21.4754\" stroke-miterlimit=\"10\"></path><path d=\"M2.18269 2.17082L6 5.97804M6.52398 2.86516L6.53597 6.51259L2.88498 6.52456\" stroke-miterlimit=\"10\"></path><path d=\"M19.8726 12.4064C19.8726 14.6668 17.117 16.4992 13.717 16.4992C10.378 16.4992 7.66682 14.7302 7.5709 12.5256V15.6234C7.5709 17.8838 10.3265 19.7162 13.7266 19.7162C17.1266 19.7162 19.8822 17.8838 19.8822 15.6234C19.8822 15.3443 19.9537 12.6699 19.8735 12.4055L19.8726 12.4064Z\"></path><path d=\"M13.7169 16.4993C17.116 16.4993 19.8725 14.6668 19.8725 12.4065C19.8725 10.1461 17.1169 8.31367 13.7169 8.31367C10.3168 8.31367 7.56121 10.1461 7.56121 12.4065C7.56121 14.6668 10.3168 16.4993 13.7169 16.4993Z\"></path></g></svg>";

                public Crowdloans() : base("Crowdloans", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class RelayChain : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M14 26C20.6274 26 26 20.6274 26 14C26 7.37258 20.6274 2 14 2C7.37258 2 2 7.37258 2 14C2 20.6274 7.37258 26 14 26Z\"></path><path d=\"M14 18C16.2091 18 18 16.2091 18 14C18 11.7909 16.2091 10 14 10C11.7909 10 10 11.7909 10 14C10 16.2091 11.7909 18 14 18Z\"></path><path d=\"M14.0078 6.01711L13.9907 6\" stroke-miterlimit=\"10\"></path><path d=\"M14.0078 22L13.9907 21.9829\" stroke-miterlimit=\"10\"></path><path d=\"M21.9834 14.0086L22.0005 13.9915\" stroke-miterlimit=\"10\"></path><path d=\"M6 14.0086L6.01711 13.9915\" stroke-miterlimit=\"10\"></path><path d=\"M19.6507 8.36254V8.33691\" stroke-miterlimit=\"10\"></path><path d=\"M8.34877 19.6641V19.6385\" stroke-miterlimit=\"10\"></path><path d=\"M19.6379 19.6513H19.6636\" stroke-miterlimit=\"10\"></path><path d=\"M8.33597 8.34973H8.3616\" stroke-miterlimit=\"10\"></path></svg>";

                public RelayChain() : base("RelayChain", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Whitepaper : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M5.00001 26.0005V2.00049H17L23.4615 8.46203V26.0005H5.00001Z\"></path><path d=\"M23 8.46201H17V2.50024\"></path></svg>";

                public Whitepaper() : base("Whitepaper", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class DayMode : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 28\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M14.0528 19.1297C16.8142 19.1297 19.0528 16.8901 19.0528 14.1273C19.0528 11.3646 16.8142 9.12502 14.0528 9.12502C11.2914 9.12502 9.0528 11.3646 9.0528 14.1273C9.0528 16.8901 11.2914 19.1297 14.0528 19.1297Z\"></path><path d=\"M14.0527 26.125L14.0527 23.125\"></path><path d=\"M14.5381 5.125L14.5381 2.125\"></path><path d=\"M2.05273 14.125L5.05273 14.125\"></path><path d=\"M23.0527 14.125L26.0527 14.125\"></path><path d=\"M5.56722 22.6103L7.68854 20.489\"></path><path d=\"M20.9019 7.76112L23.0232 5.6398\"></path><path d=\"M6.05281 5.6397L8.17413 7.76102\"></path><path d=\"M20.4167 20.4889L22.538 22.6102\"></path></svg>";

                public DayMode() : base("DayMode", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class DarkMode : Icon
            {
                private const string SVG_CONTENT = "<svg width=\"18\" height=\"18\" viewBox=\"0 0 28 29\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\" stroke-width=\"1\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke=\"var(--accent-fill-rest)\"><path d=\"M24.933 18.407C22.9658 20.0772 20.2425 20.7935 17.5563 20.0914C13.1808 18.9478 10.5609 14.4736 11.7045 10.0981C12.6333 6.54463 15.7587 4.14906 19.244 3.98694C18.5497 3.6436 17.8103 3.36531 17.0315 3.16175C10.8543 1.54717 4.53783 5.24589 2.92325 11.4231C1.30867 17.6002 5.00739 23.9167 11.1846 25.5313C16.9727 27.0442 22.8831 23.892 24.933 18.407Z\"></path></svg>";

                public DarkMode() : base("DarkMode", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }
        }

        public static class BootstrapIcon
        {
            public class CardText : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-card-text\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2z\"/>\r\n  <path d=\"M3 5.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5M3 8a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 8m0 2.5a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5\"/>\r\n</svg>";

                public CardText() : base("CardText", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Table : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-table\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2zm15 2h-4v3h4zm0 4h-4v3h4zm0 4h-4v3h3a1 1 0 0 0 1-1zm-5 3v-3H6v3zm-5 0v-3H1v2a1 1 0 0 0 1 1zm-4-4h4V8H1zm0-4h4V4H1zm5-3v3h4V4zm4 4H6v3h4z\"/>\r\n</svg>";

                public Table() : base("Table", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Coin : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-coin\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M5.5 9.511c.076.954.83 1.697 2.182 1.785V12h.6v-.709c1.4-.098 2.218-.846 2.218-1.932 0-.987-.626-1.496-1.745-1.76l-.473-.112V5.57c.6.068.982.396 1.074.85h1.052c-.076-.919-.864-1.638-2.126-1.716V4h-.6v.719c-1.195.117-2.01.836-2.01 1.853 0 .9.606 1.472 1.613 1.707l.397.098v2.034c-.615-.093-1.022-.43-1.114-.9zm2.177-2.166c-.59-.137-.91-.416-.91-.836 0-.47.345-.822.915-.925v1.76h-.005zm.692 1.193c.717.166 1.048.435 1.048.91 0 .542-.412.914-1.135.982V8.518z\"/>\r\n  <path d=\"M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16\"/>\r\n  <path d=\"M8 13.5a5.5 5.5 0 1 1 0-11 5.5 5.5 0 0 1 0 11m0 .5A6 6 0 1 0 8 2a6 6 0 0 0 0 12\"/>\r\n</svg>";

                public Coin() : base("Coin", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Chrome : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-browser-chrome\" viewBox=\"0 0 16 16\">\r\n  <path fill-rule=\"evenodd\" d=\"M16 8a8 8 0 0 1-7.022 7.94l1.902-7.098a3 3 0 0 0 .05-1.492A3 3 0 0 0 10.237 6h5.511A8 8 0 0 1 16 8M0 8a8 8 0 0 0 7.927 8l1.426-5.321a3 3 0 0 1-.723.255 3 3 0 0 1-1.743-.147 3 3 0 0 1-1.043-.7L.633 4.876A8 8 0 0 0 0 8m5.004-.167L1.108 3.936A8.003 8.003 0 0 1 15.418 5H8.066a3 3 0 0 0-1.252.243 2.99 2.99 0 0 0-1.81 2.59M8 10a2 2 0 1 0 0-4 2 2 0 0 0 0 4\"/>\r\n</svg>";

                public Chrome() : base("Chrome", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Github : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-github\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M8 0C3.58 0 0 3.58 0 8c0 3.54 2.29 6.53 5.47 7.59.4.07.55-.17.55-.38 0-.19-.01-.82-.01-1.49-2.01.37-2.53-.49-2.69-.94-.09-.23-.48-.94-.82-1.13-.28-.15-.68-.52-.01-.53.63-.01 1.08.58 1.23.82.72 1.21 1.87.87 2.33.66.07-.52.28-.87.51-1.07-1.78-.2-3.64-.89-3.64-3.95 0-.87.31-1.59.82-2.15-.08-.2-.36-1.02.08-2.12 0 0 .67-.21 2.2.82.64-.18 1.32-.27 2-.27.68 0 1.36.09 2 .27 1.53-1.04 2.2-.82 2.2-.82.44 1.1.16 1.92.08 2.12.51.56.82 1.27.82 2.15 0 3.07-1.87 3.75-3.65 3.95.29.25.54.73.54 1.48 0 1.07-.01 1.93-.01 2.2 0 .21.15.46.55.38A8.012 8.012 0 0 0 16 8c0-4.42-3.58-8-8-8z\"/>\r\n</svg>";

                public Github() : base("Github", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Twitter : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-twitter\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z\"/>\r\n</svg>";

                public Twitter() : base("Twitter", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Discord : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-discord\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M13.545 2.907a13.2 13.2 0 0 0-3.257-1.011.05.05 0 0 0-.052.025c-.141.25-.297.577-.406.833a12.2 12.2 0 0 0-3.658 0 8 8 0 0 0-.412-.833.05.05 0 0 0-.052-.025c-1.125.194-2.22.534-3.257 1.011a.04.04 0 0 0-.021.018C.356 6.024-.213 9.047.066 12.032q.003.022.021.037a13.3 13.3 0 0 0 3.995 2.02.05.05 0 0 0 .056-.019q.463-.63.818-1.329a.05.05 0 0 0-.01-.059l-.018-.011a9 9 0 0 1-1.248-.595.05.05 0 0 1-.02-.066l.015-.019q.127-.095.248-.195a.05.05 0 0 1 .051-.007c2.619 1.196 5.454 1.196 8.041 0a.05.05 0 0 1 .053.007q.121.1.248.195a.05.05 0 0 1-.004.085 8 8 0 0 1-1.249.594.05.05 0 0 0-.03.03.05.05 0 0 0 .003.041c.24.465.515.909.817 1.329a.05.05 0 0 0 .056.019 13.2 13.2 0 0 0 4.001-2.02.05.05 0 0 0 .021-.037c.334-3.451-.559-6.449-2.366-9.106a.03.03 0 0 0-.02-.019m-8.198 7.307c-.789 0-1.438-.724-1.438-1.612s.637-1.613 1.438-1.613c.807 0 1.45.73 1.438 1.613 0 .888-.637 1.612-1.438 1.612m5.316 0c-.788 0-1.438-.724-1.438-1.612s.637-1.613 1.438-1.613c.807 0 1.451.73 1.438 1.613 0 .888-.631 1.612-1.438 1.612\"/>\r\n</svg>";

                public Discord() : base("Discord", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Medium : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-medium\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M9.025 8c0 2.485-2.02 4.5-4.513 4.5A4.506 4.506 0 0 1 0 8c0-2.486 2.02-4.5 4.512-4.5A4.506 4.506 0 0 1 9.025 8m4.95 0c0 2.34-1.01 4.236-2.256 4.236S9.463 10.339 9.463 8c0-2.34 1.01-4.236 2.256-4.236S13.975 5.661 13.975 8M16 8c0 2.096-.355 3.795-.794 3.795-.438 0-.793-1.7-.793-3.795 0-2.096.355-3.795.794-3.795.438 0 .793 1.699.793 3.795\"/>\r\n</svg>";

                public Medium() : base("Medium", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Telegram : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-telegram\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M8.287 5.906q-1.168.486-4.666 2.01-.567.225-.595.442c-.03.243.275.339.69.47l.175.055c.408.133.958.288 1.243.294q.39.01.868-.32 3.269-2.206 3.374-2.23c.05-.012.12-.026.166.016s.042.12.037.141c-.03.129-1.227 1.241-1.846 1.817-.193.18-.33.307-.358.336a8 8 0 0 1-.188.186c-.38.366-.664.64.015 1.088.327.216.589.393.85.571.284.194.568.387.936.629q.14.092.27.187c.331.236.63.448.997.414.214-.02.435-.22.547-.82.265-1.417.786-4.486.906-5.751a1.4 1.4 0 0 0-.013-.315.34.34 0 0 0-.114-.217.53.53 0 0 0-.31-.093c-.3.005-.763.166-2.984 1.09\"/>\r\n</svg>";

                public Telegram() : base("Telegram", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Members : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-people-fill\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6m-5.784 6A2.24 2.24 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.3 6.3 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1zM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5\"/>\r\n</svg>";

                public Members() : base("Members", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Hourglass : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-hourglass\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M2 1.5a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-1v1a4.5 4.5 0 0 1-2.557 4.06c-.29.139-.443.377-.443.59v.7c0 .213.154.451.443.59A4.5 4.5 0 0 1 12.5 13v1h1a.5.5 0 0 1 0 1h-11a.5.5 0 1 1 0-1h1v-1a4.5 4.5 0 0 1 2.557-4.06c.29-.139.443-.377.443-.59v-.7c0-.213-.154-.451-.443-.59A4.5 4.5 0 0 1 3.5 3V2h-1a.5.5 0 0 1-.5-.5zm2.5.5v1a3.5 3.5 0 0 0 1.989 3.158c.533.256 1.011.791 1.011 1.491v.702c0 .7-.478 1.235-1.011 1.491A3.5 3.5 0 0 0 4.5 13v1h7v-1a3.5 3.5 0 0 0-1.989-3.158C8.978 9.586 8.5 9.052 8.5 8.351v-.702c0-.7.478-1.235 1.011-1.491A3.5 3.5 0 0 0 11.5 3V2h-7z\"/>\r\n</svg>";

                public Hourglass() : base("Hourglass", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class HourglassBottom : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-hourglass-bottom\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M2 1.5a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-1v1a4.5 4.5 0 0 1-2.557 4.06c-.29.139-.443.377-.443.59v.7c0 .213.154.451.443.59A4.5 4.5 0 0 1 12.5 13v1h1a.5.5 0 0 1 0 1h-11a.5.5 0 1 1 0-1h1v-1a4.5 4.5 0 0 1 2.557-4.06c.29-.139.443-.377.443-.59v-.7c0-.213-.154-.451-.443-.59A4.5 4.5 0 0 1 3.5 3V2h-1a.5.5 0 0 1-.5-.5zm2.5.5v1a3.5 3.5 0 0 0 1.989 3.158c.533.256 1.011.791 1.011 1.491v.702s.18.149.5.149.5-.15.5-.15v-.7c0-.701.478-1.236 1.011-1.492A3.5 3.5 0 0 0 11.5 3V2h-7z\"/>\r\n</svg>";

                public HourglassBottom() : base("HourglassBottom", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class HourglassTop : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-hourglass-top\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M2 14.5a.5.5 0 0 0 .5.5h11a.5.5 0 1 0 0-1h-1v-1a4.5 4.5 0 0 0-2.557-4.06c-.29-.139-.443-.377-.443-.59v-.7c0-.213.154-.451.443-.59A4.5 4.5 0 0 0 12.5 3V2h1a.5.5 0 0 0 0-1h-11a.5.5 0 0 0 0 1h1v1a4.5 4.5 0 0 0 2.557 4.06c.29.139.443.377.443.59v.7c0 .213-.154.451-.443.59A4.5 4.5 0 0 0 3.5 13v1h-1a.5.5 0 0 0-.5.5zm2.5-.5v-1a3.5 3.5 0 0 1 1.989-3.158c.533-.256 1.011-.79 1.011-1.491v-.702s.18.101.5.101.5-.1.5-.1v.7c0 .701.478 1.236 1.011 1.492A3.5 3.5 0 0 1 11.5 13v1h-7z\"/>\r\n</svg>";

                public HourglassTop() : base("HourglassTop", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }

            public class Book : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-book\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M1 2.828c.885-.37 2.154-.769 3.388-.893 1.33-.134 2.458.063 3.112.752v9.746c-.935-.53-2.12-.603-3.213-.493-1.18.12-2.37.461-3.287.811zm7.5-.141c.654-.689 1.782-.886 3.112-.752 1.234.124 2.503.523 3.388.893v9.923c-.918-.35-2.107-.692-3.287-.81-1.094-.111-2.278-.039-3.213.492zM8 1.783C7.015.936 5.587.81 4.287.94c-1.514.153-3.042.672-3.994 1.105A.5.5 0 0 0 0 2.5v11a.5.5 0 0 0 .707.455c.882-.4 2.303-.881 3.68-1.02 1.409-.142 2.59.087 3.223.877a.5.5 0 0 0 .78 0c.633-.79 1.814-1.019 3.222-.877 1.378.139 2.8.62 3.681 1.02A.5.5 0 0 0 16 13.5v-11a.5.5 0 0 0-.293-.455c-.952-.433-2.48-.952-3.994-1.105C10.413.809 8.985.936 8 1.783\"/>\r\n</svg>";

                public Book() : base("Book", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }
        }
    }
    
}
