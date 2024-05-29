﻿using System.ComponentModel.DataAnnotations;
using LenovoLegionToolkit.Lib.Automation.Resources;

namespace LenovoLegionToolkit.Lib.Automation;

public enum DeactivateGPUAutomationStepState
{
    [Display(ResourceType = typeof(Resource), Name = "DeactivateGPUAutomationStepState_KillApps")]
    KillApps,
    [Display(ResourceType = typeof(Resource), Name = "DeactivateGPUAutomationStepState_RestartGPU")]
    RestartGPU,
}

public enum MacroAutomationStepState
{
    [Display(ResourceType = typeof(Resource), Name = "MacroAutomationStepState_Off")]
    Off,
    [Display(ResourceType = typeof(Resource), Name = "MacroAutomationStepState_On")]
    On
}

public enum OverclockDiscreteGPUAutomationStepState
{
    [Display(ResourceType = typeof(Resource), Name = "OverclockDiscreteGPUAutomationStepState_Off")]
    Off,
    [Display(ResourceType = typeof(Resource), Name = "OverclockDiscreteGPUAutomationStepState_On")]
    On
}

public enum CmdLineQuickActionRunState
{
    Ok,
    ActionNotFound,
    ActionRunFailed,
    DeserializeFailed
}
