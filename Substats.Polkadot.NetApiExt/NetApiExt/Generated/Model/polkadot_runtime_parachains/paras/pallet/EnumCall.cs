//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.pallet
{
    
    
    public enum Call
    {
        
        force_set_current_code = 0,
        
        force_set_current_head = 1,
        
        force_schedule_code_upgrade = 2,
        
        force_note_new_head = 3,
        
        force_queue_action = 4,
        
        add_trusted_validation_code = 5,
        
        poke_unused_validation_code = 6,
        
        include_pvf_check_statement = 7,
    }
    
    /// <summary>
    /// >> 407 - Variant[polkadot_runtime_parachains.paras.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.HeadData>, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCode, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash, BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.PvfCheckStatement, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.validator_app.Signature>>
    {
    }
}
