using Microsoft.FluentUI.AspNetCore.Components;
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

            public class Members : Icon
            {
                private const string SVG_CONTENT = "<svg xmlns=\"http://www.w3.org/2000/svg\" class=\"bi bi-people-fill\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M7 14s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1zm4-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6m-5.784 6A2.24 2.24 0 0 1 5 13c0-1.355.68-2.75 1.936-3.72A6.3 6.3 0 0 0 5 9c-4 0-5 3-5 4s1 1 1 1zM4.5 8a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5\"/>\r\n</svg>";

                public Members() : base("Members", IconVariant.Regular, IconSize.Custom, SVG_CONTENT)
                {
                }
            }
        }
    }
    
}
