using System.Diagnostics;
using discipline.ui.infrastructure.DailyTrackers.DTOs;
using discipline.ui.infrastructure.DailyTrackers.Models;
using Shouldly;
using Xunit;

namespace discipline.ui.infrastructure.tests.DailyTrackers.Models;

public sealed class ActivityModelTests
{

    [Fact]
    public void ChangeStageIndexShouldChangePrecisedStageIndexAndResetRestOfIndexesWhenCorrectlyCalledMethod()
    {
        //arrange 
        var stage1 = StageModel.Create(Guid.NewGuid().ToString(), "test_title_stage1", 1, false);
        var stage2 = StageModel.Create(Guid.NewGuid().ToString(), "test_title_stage2", 2, false);
        
        var activity = ActivityModel.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
            "test_activity_title", null, false, [stage1, stage2]);
        
        //act
        activity.ChangeStageIndex(2, 1);
        
        //assert
        stage1.Index.ShouldBe(2);
        stage2.Index.ShouldBe(1);
    }
}